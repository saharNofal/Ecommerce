import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from './product.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-product',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css']
})
export class ProductAddComponent implements OnInit {
  productForm: FormGroup;
  productId: number = 0;

  categories: any[] = []; 

  constructor(private fb: FormBuilder, 
              private productService: ProductService,
              private route: ActivatedRoute,
              private http: HttpClient,
              private router: Router) {
    this.productForm = this.fb.group({
      Name: ['', Validators.required],
      Price: [0, Validators.required],
      Description: [''],
      CategoryId: ['', Validators.required],
      ImagePath: '',
      ProductId:0
    });
  }

  ngOnInit(): void {
    debugger;
    this.productId = this.route.snapshot.params['productId'];
    if(this.productId!= null)
      {
        this.loadProudct(this.productId )
      }
   
    this.productService.getCategories().subscribe((categories: any[]) => {
      this.categories = categories;
    });
  }

  
  loadProudct(productId: number): void {
    debugger;
    this.http.get<any>('https://localhost:7043/api/Products/GetProductById?proudectId=' + productId)
      .subscribe(product => {
        debugger;
        this.productForm.patchValue({
          Name: product.name,
          ProductId:product.productId,
          Price: product.price,
          Description: product.description,
          CategoryId: product.categoryId,
          ImagePath: product.imagePath 
        });
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
