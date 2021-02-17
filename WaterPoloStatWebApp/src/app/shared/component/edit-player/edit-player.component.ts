import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Player } from '../../models/player';
import { ValidationMessagesService } from '../../services/validationMessages.service';
import {map, startWith} from 'rxjs/operators';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html'
})
export class EditPlayerComponent implements OnInit {

  @Input() rosterFormGroup: FormGroup;

  options: string[] = ['One', 'Two', 'Three'];
  filteredOptions: Observable<string[]>;
  constructor(private formBuilder: FormBuilder,
    public validationMessages: ValidationMessagesService) { }

  get nome() { return this.rosterFormGroup.get('nome'); }
  get roster(): FormArray { return this.rosterFormGroup.get('giocatori') as FormArray; }
  ngOnInit(): void {
    this.filteredOptions = this.nome.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();

    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  }
  addPlayer(): void {
    this.roster.push(this.formBuilder.group({
      nome: ['', [Validators.required]],
      data: ['', [Validators.required]],
      ruolo: ['', [Validators.required]],
      numero: [null, [Validators.required]],
      giocatoreId: [null]
    }));
  }

  removePlayer(index: number): void {
    this.roster.removeAt(index);
  }

}
