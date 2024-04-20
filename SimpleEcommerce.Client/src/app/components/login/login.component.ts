import { Component, Output, EventEmitter } from '@angular/core';
import { AuthService } from './auth.service';

interface LoginResponse {
  token: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private authService: AuthService) {}

  @Output() onLoggedIn: EventEmitter<boolean> = new EventEmitter<boolean>();

  email!: string;
  password!: string;

  onSubmit(): void {
    this.authService.login(this.email, this.password)
      .subscribe(
        (response: LoginResponse) => {
          debugger;
          localStorage.setItem('token', response.token);
          this.onLoggedIn.emit(true);
           },
        error => {
        }
      );
  }
}
