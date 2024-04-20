import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ProductService } from './product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  productForm: FormGroup;
  categories: any[] = []; // Change to array to hold multiple category objects

  constructor(private fb: FormBuilder, 
              private productService: ProductService,
              private router: Router) {
    this.productForm = this.fb.group({
      Name: ['', Validators.required],
      Price: [0, Validators.required],
      Description: [''],
      CategoryId: ['', Validators.required],
      ImagePath: ''
    });
  }

  ngOnInit(): void {
    this.productService.getCategories().subscribe((categories: any[]) => {
      this.categories = categories;
    });
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      const formData = this.productForm.value;

      this.productService.addProduct(formData).subscribe(
        (response: any) => {
          console.log('Product added successfully:', response);
          this.productForm.reset();
          this.router.navigate(['/Product']);
        },
        (error: any) => {
          console.error('Error adding product:', error);
        }
      );
    } else {
      this.productForm.markAllAsTouched();
    }
  }

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      this.productService.uploadImage(file).subscribe(
        (response: any) => {
          this.productForm.patchValue({ ImagePath: response.path });
        },
        (error: any) => {
          console.error('Error uploading image:', error);
        }
      );
    }
  }
}
