import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './shared/models/user';
import { AuthService } from './shared/services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.sass']
})
export class AppComponent {
currentUser!: User | null;

    constructor(
        private router: Router,
        private authenticationService: AuthService
    ) {
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}
