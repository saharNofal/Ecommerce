// product-list.component.ts
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  products: any[] = [];
  categories: any[] = [];
  filteredProducts: any[] = [];
  selectedCategory: any = '';

  constructor(private productService: ProductService, private router: Router) {}

  ngOnInit(): void {
    this.loadProducts(0);
    this.loadCategories();
  }

  loadProducts(categoryId: any): void {
    this.productService.getProductById(categoryId).subscribe((products: any[]) => {
      this.products = products;
      this.filterProducts();
    });
  }

  loadCategories(): void {
    this.productService.getCategories().subscribe((categories: any[]) => {
      this.categories = categories;
    });
  }

  filterProducts(): void {
    this.filteredProducts = this.selectedCategory ?
      this.products.filter(product => product.categoryId == this.selectedCategory) :
      this.products;
  }

  getCategoryName(categoryId: any): string {
    const category = this.categories.find(c => c.categoryId === categoryId);
    return category ? category.name : '';
  }

  editProduct(productId: number): void {
    this.router.navigate(['/EditProduct', productId]);
  }

  deleteProduct(productId: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(productId).subscribe(
        () => {
          console.log('Product deleted successfully');
          this.loadProducts(this.selectedCategory);
        },
        (error: any) => {
          console.error('Error deleting product:', error);
        }
      );
    }
  }
}
