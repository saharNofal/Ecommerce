import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent {
  CreateCategoryCommand: any = { Name: '', Description: '' }; // Initialize category object with empty values


  constructor(private http: HttpClient, private router: Router) { }

  onSubmit(): void {
    debugger
    this.http.post<any>('https://localhost:7043/api/Category/Add', this.CreateCategoryCommand)
      .subscribe(() => {
        this.router.navigate(['/Category']);

      });
  }
}
