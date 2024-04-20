import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.css']
})
export class EditCategoryComponent implements OnInit {



  categoryId: number = 0;
  CreateCategoryCommand: any = {};

  constructor(private route: ActivatedRoute, private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    debugger;
    this.categoryId = this.route.snapshot.params['categoryId'];
    this.loadCategory(this.categoryId);
  }

  loadCategory(categoryId: number): void {
    debugger;
    this.http.get<any>('https://localhost:7043/api/Category/GetCategoryById?categoryId=' + categoryId)
      .subscribe(category => {
        debugger;
        this.CreateCategoryCommand = category;
      });
  }

  onSubmit(): void {
    debugger
    this.http.post<any>('https://localhost:7043/api/Category/Add', this.CreateCategoryCommand)
      .subscribe(() => {
        this.router.navigate(['/Category']);

      });
  }
}
