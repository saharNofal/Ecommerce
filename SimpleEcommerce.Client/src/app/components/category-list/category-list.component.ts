import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'; // Import Router for navigation

interface Category {
  categoryId: number;
  name: string;
  description: string;
}

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories: Category[] | undefined;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.loadCategories();
  }

  loadCategories(): void {
    this.http.get<Category[]>('https://localhost:7043/api/Category/all')
      .subscribe(categories => {
        debugger;
        this.categories = categories;
      });
  }
  addCategory(): void {
    debugger;

    this.router.navigate(['/Add-category']);

  }
  editCategory(category: Category): void {
    this.router.navigate(['/edit-category', category.categoryId]);
  }

  viewDetails(category: Category): void {
    this.router.navigate(['/category-details', category.categoryId]);
  }
}
