import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidationMessagesService } from '../../services/validationMessages.service';

@Component({
  selector: 'app-modifica-roster',
  templateUrl: './modifica-roster.component.html'
})
export class ModificaRosterComponent implements OnInit {
  @Input() rosterFormGroup!: FormGroup;
  
  constructor(private formBuilder: FormBuilder,
    public validationMessages: ValidationMessagesService) { }

  get nome() { return this.rosterFormGroup.get('nome'); }
  get roster(): FormArray { return this.rosterFormGroup.get('giocatori') as FormArray; }

  ngOnInit(): void {
  }
  addPlayer(): void {
    this.roster.push(this.formBuilder.group({
      nome: ['', [Validators.required]],
      data: ['', [Validators.required]],
      ruoloId: ['', [Validators.required]],
      numero: [null, [Validators.required]],
      giocatoreId: [null]
    }));
  }

  removePlayer(index: number): void {
    this.roster.removeAt(index);
  }

}
