import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  @Input() isLoggedIn: boolean = false;

  logout(): void {
    localStorage.removeItem('token');
    this.isLoggedIn = false;
  }
}
