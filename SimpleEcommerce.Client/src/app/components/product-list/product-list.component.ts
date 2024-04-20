import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from './product.service'; // Import ProductService

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
    this.loadProducts();
    this.loadCategories();
  }

  loadProducts(): void {
    this.productService.getProducts().subscribe((products: any[]) => {
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
      this.products.filter(product => product.CategoryId == this.selectedCategory) :
      this.products;
  }

  getCategoryName(categoryId: any): string {
    const category = this.categories.find(c => c.categoryId === categoryId);
    return category ? category.name : '';
  }

  editProduct(productId: number): void {
    this.router.navigate(['/edit-product', productId]);
  }

  deleteProduct(productId: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(productId).subscribe(
        () => {
          console.log('Product deleted successfully');
          this.loadProducts();
        },
        (error: any) => {
          console.error('Error deleting product:', error);
        }
      );
    }
  }
}
