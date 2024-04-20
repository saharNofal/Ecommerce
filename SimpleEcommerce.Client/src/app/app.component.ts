import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Simple Ecommerce For Client';
  isLoggedIn = false;

  
  onLoggedIn(event: any) {
    debugger;
    this.isLoggedIn = event;
  }
}



