import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NuovaRegistrazione } from '../shared/models/nuovaRegistrazione';
import { UserService } from '../shared/services/userService';
import { ValidationMessagesService } from '../shared/services/validationMessages.service';
import { ValidatorsService } from '../shared/services/validators.service';

@Component({
  selector: 'app-registrazione',
  templateUrl: './registrazione.component.html'
})
export class RegistrazioneComponent implements OnInit {
  public registrazioneFormGroup = this.formBuilder.group({
    nome: ['', [Validators.required]],
    cognome: ['', [Validators.required]],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]],
    confermaPassword: ['', [Validators.required]],
    consensoDati: [false, [Validators.requiredTrue]]
  });
  constructor(private formBuilder: FormBuilder, private customValidators: ValidatorsService,
    public validationMessages: ValidationMessagesService, private userService: UserService, 
    private router: Router) { }

    public error!: string;
    public registrazioneOk: boolean = false;
  get nome() { return this.registrazioneFormGroup.get('nome'); }
  get cognome() { return this.registrazioneFormGroup.get('cognome'); }
  get email() { return this.registrazioneFormGroup.get('email'); }
  get password() { return this.registrazioneFormGroup.get('password'); }
  get confermaPassword() { return this.registrazioneFormGroup.get('confermaPassword'); }
  get consensoDati() { return this.registrazioneFormGroup.get('consensoDati'); }

  ngOnInit(): void {
    if (this.password != null) {
      this.registrazioneFormGroup.get('confermaPassword')?.setValidators([Validators.required, Validators.maxLength(255), this.customValidators.compare2Field(this.password)]);
    }
  }

  onSubmit():void{
    this.registrazioneFormGroup.markAllAsTouched();
    let nuovoutente:NuovaRegistrazione = { ...NuovaRegistrazione, ...this.registrazioneFormGroup.getRawValue() };
    //console.log(nuovoutente);
    this.userService.registra(nuovoutente).subscribe({
      next: () => {
          this.registrazioneOk = true;
      },
      error: error => {
          this.error = error.errors[0];
      }});
  }
}
