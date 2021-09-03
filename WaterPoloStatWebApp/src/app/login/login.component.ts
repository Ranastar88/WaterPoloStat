import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AuthService } from '../shared/services/auth.service';
import { ValidationMessagesService } from '../shared/services/validationMessages.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  public error!: string;
  public loginFormGroup = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required]]
  });
  constructor(private formBuilder: FormBuilder,
    public validationMessages: ValidationMessagesService,
    private authService: AuthService, 
    private router: Router,    
    private route: ActivatedRoute) { }

    get email() { return this.loginFormGroup.get('email'); }
    get password() { return this.loginFormGroup.get('password'); }
  ngOnInit(): void {
  }

  login() {
    const val = this.loginFormGroup.value;

    if (val.email && val.password) {
        this.authService.login(val.email, val.password)
            .subscribe(
                () => {
                    console.log("User is logged in");
                    this.router.navigateByUrl('/');
                }
            );
    }
}
onSubmit() {
  this.loginFormGroup.markAllAsTouched();
  // stop here if form is invalid
  if (this.loginFormGroup.invalid) {
      return;
  }

  this.authService.login(this.email?.value, this.password?.value)
      .pipe(first())
      .subscribe({
          next: () => {
              // get return url from route parameters or default to '/'
              const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
              this.router.navigate([returnUrl]);
          },
          error: error => {
              this.error = error.errors[0];
          }
      });
}

}
