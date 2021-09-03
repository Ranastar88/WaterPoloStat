import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { takeUntil } from 'rxjs/operators';
import { NewEditPartita } from '../shared/models/newEditPartita';
import { NewEditSquadra } from '../shared/models/newEditSquadra';
import { PartitaService } from '../shared/services/partitaService';
import { ValidationMessagesService } from '../shared/services/validationMessages.service';

@Component({
  selector: 'app-modifica-partita',
  templateUrl: './modifica-partita.component.html'
})
export class ModificaPartitaComponent implements OnInit {
  public id!: number;
  public error!: string;
  public infoFormGroup = this.formBuilder.group({
    data: ['', [Validators.required]],
    campionato: ['', [Validators.required]],
    luogo: ['', [Validators.required]],
    citta: ['', [Validators.required]]
  });
  public squadraCasaFormGroup: FormGroup = this.formBuilder.group({
    nome: ['', [Validators.required]],
    squadraId: [null],
    giocatori: this.formBuilder.array([this.formBuilder.group({
      nome: ['', [Validators.required]],
      data: ['', [Validators.required]],
      ruoloId: ['', [Validators.required]],
      numero: [null, [Validators.required]],
      giocatoreId: [null]
    })])
  });
  public squadraOspitiFormGroup: FormGroup = this.formBuilder.group({
    nome: ['', [Validators.required]],
    squadraId: [null],
    giocatori: this.formBuilder.array([this.formBuilder.group({
      nome: ['', [Validators.required]],
      data: ['', [Validators.required]],
      ruoloId: ['', [Validators.required]],
      numero: [null, [Validators.required]],
      giocatoreId: [null]
    })])
  });

  constructor(private formBuilder: FormBuilder,
    public validationMessages: ValidationMessagesService,
    public partitaService: PartitaService,
    private router: Router, public route: ActivatedRoute) { }

  get data() { return this.infoFormGroup.get('data'); }
  get campionato() { return this.infoFormGroup.get('campionato'); }
  get luogo() { return this.infoFormGroup.get('luogo'); }
  get citta() { return this.infoFormGroup.get('citta'); }

  ngOnInit(): void {
    this.route.paramMap.subscribe(paramMap => {
      var id = paramMap.get('id');
      if (id != null) {
        this.id = Number.parseInt(id);
        this.partitaService.getPartita(Number.parseInt(id)).subscribe({
          next: (result) => {
            this.infoFormGroup.patchValue(result);
            this.squadraCasaFormGroup.patchValue(result.squadraCasa);
            this.squadraOspitiFormGroup.patchValue(result.squadraOspiti);
          }
        });
      }
    });
  }
  onSubmit(): void {
    if (this.id == null) {
      let nuovapartita: NewEditPartita = { ...NewEditPartita, ...this.infoFormGroup.getRawValue() };
      nuovapartita.squadraCasa = { ...NewEditSquadra, ...this.squadraCasaFormGroup.getRawValue() };
      nuovapartita.squadraOspiti = { ...NewEditSquadra, ...this.squadraOspitiFormGroup.getRawValue() };
      this.partitaService.nuova(nuovapartita).subscribe({
        next: () => {
          this.router.navigate(["/"]);
        },
        error: error => {
          this.error = error.errors[0];
        }
      });
    } else {
      let modificapartita: NewEditPartita = { ...NewEditPartita, ...this.infoFormGroup.getRawValue() };
      modificapartita.squadraCasa = { ...NewEditSquadra, ...this.squadraCasaFormGroup.getRawValue() };
      modificapartita.squadraOspiti = { ...NewEditSquadra, ...this.squadraOspitiFormGroup.getRawValue() };
      this.partitaService.aggiorna(this.id,modificapartita).subscribe({
        next: () => {
          this.router.navigate(["/"]);
        },
        error: error => {
          this.error = error.errors[0];
        }
      });
    }

  }
}
