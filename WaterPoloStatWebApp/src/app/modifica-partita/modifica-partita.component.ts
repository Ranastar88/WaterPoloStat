import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidationMessagesService } from '../shared/services/validationMessages.service';

@Component({
  selector: 'app-modifica-partita',
  templateUrl: './modifica-partita.component.html'
})
export class ModificaPartitaComponent implements OnInit {
  public infoFormGroup = this.formBuilder.group({
    data: ['', [Validators.required]],
    campionato: ['', [Validators.required]],
    luogo: ['', [Validators.required]],
    categoria: ['', [Validators.required]]
  });

  public squadraCasaFormGroup;
  constructor(private formBuilder: FormBuilder,
    public validationMessages: ValidationMessagesService) { }

  get data() { return this.infoFormGroup.get('data'); }
  get campionato() { return this.infoFormGroup.get('campionato'); }
  get luogo() { return this.infoFormGroup.get('luogo'); }
  get categoria() { return this.infoFormGroup.get('categoria'); }


  ngOnInit(): void {

    //set giocatori
    this.squadraCasaFormGroup = this.formBuilder.group({
      nome: ['sda', [Validators.required]],
      squadraId: [null],
      giocatori: this.formBuilder.array([...this.createPlayer()])
    });
  }

  private createPlayer(): FormGroup[] {
    const arr = [];
    for (let i = 1; i < 15; i++) {
      arr.push(this.formBuilder.group({
        nome: ['', [Validators.required]],
        data: ['', [Validators.required]],
        ruolo: ['', [Validators.required]],
        numero: [i, [Validators.required]],
        giocatoreId: [null]
      }));
    }
    return arr;
  }

}
