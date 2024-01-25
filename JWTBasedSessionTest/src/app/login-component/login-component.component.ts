import { Component } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-login-component',
  template: `
        <form (ngSubmit)="login()">
            <input [(ngModel)]="username" placeholder="Username" name="username" />
            <input [(ngModel)]="password" type="password" placeholder="Password" name="password" />
            <button type="submit">Login</button>
        </form>
    `,
  // templateUrl: './login-component.component.html',
  // styleUrl: './login-component.component.css'
})
export class LoginComponentComponent {
  username: string = '';
    password: string = '';

    constructor(private authService: AuthService) {}

    login() {
        this.authService.login(this.username, this.password).subscribe(response => {
            // Handle successful login, save token, redirect, etc.
            console.log('Token:', response.token);
        });
    }

}
