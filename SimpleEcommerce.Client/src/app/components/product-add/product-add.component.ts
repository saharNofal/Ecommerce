import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductService } from './product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  productForm: FormGroup;
  categories: any[] = []; // Change to array to hold multiple category objects

  constructor(private fb: FormBuilder, private productService: ProductService) {
    this.productForm = this.fb.group({
      Name: ['', Validators.required],
      Price: ['', Validators.required],
      Description: [''],
      CategoryId: ['', Validators.required],
      ImageFile: [''],
      ImagePath: ""
    });
  }

  ngOnInit(): void {
    this.productService.getCategories().subscribe((categories: any[]) => {
      debugger;
      this.categories = categories;
    });


  }

  onSubmit(): void {
    if (this.productForm.valid) {
      const formData = this.productForm.value;

      formData.price = parseFloat(formData.price);

      this.productService.addProduct(formData).subscribe(
        (response) => {

          console.log('Product added successfully:', response);
          // Optionally, reset the form after successful submission
          this.productForm.reset();
        },
        (error) => {
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