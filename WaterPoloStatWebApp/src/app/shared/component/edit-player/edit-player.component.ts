import { Component, Input, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidationMessagesService } from '../../services/validationMessages.service';

@Component({
  selector: 'app-edit-player',
  templateUrl: './edit-player.component.html'
})
export class EditPlayerComponent implements OnInit {

  @Input() rosterFormGroup: FormGroup;
  constructor(private formBuilder: FormBuilder,
    public validationMessages: ValidationMessagesService) { }

    get nome() { return this.rosterFormGroup.get('nome'); }
    get roster():FormArray { return this.rosterFormGroup.get('giocatori') as FormArray; }
  ngOnInit(): void {
  }

}
