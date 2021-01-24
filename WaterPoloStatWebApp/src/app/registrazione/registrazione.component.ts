import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ValidationMessagesService } from '../shared/services/validationMessages.service';
import { ValidatorsService } from '../shared/services/validators.service';

@Component({
  selector: 'app-registrazione',
  templateUrl: './registrazione.component.html'
})
export class RegistrazioneComponent implements OnInit {
  public registrazioneFormGroup = this.formBuilder.group({    
    nome: ['', [Validators.required]],
    email: ['', [Validators.required,Validators.email]],
    password: ['', [Validators.required]],
    confermaPassword: ['', [Validators.required]],
    consensoDati: [false,[Validators.requiredTrue]]
  });


  constructor(private formBuilder: FormBuilder,
    private customValidators: ValidatorsService,
    public validationMessages: ValidationMessagesService) { }
    
  get nome() { return this.registrazioneFormGroup.get('nome'); }
  get email() { return this.registrazioneFormGroup.get('email'); }
  get password() { return this.registrazioneFormGroup.get('password'); }
  get confermaPassword() { return this.registrazioneFormGroup.get('confermaPassword'); }
  get consensoDati() { return this.registrazioneFormGroup.get('consensoDati'); }

  ngOnInit(): void {
    this.registrazioneFormGroup.get('confermaPassword').setValidators([Validators.required, Validators.maxLength(255), this.customValidators.compare2Field(this.password)]);

  }
  onSubmit():void{
    this.registrazioneFormGroup.markAllAsTouched();
  }
}
