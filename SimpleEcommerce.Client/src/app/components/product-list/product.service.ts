import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl = 'https://localhost:7043/api';
  constructor(private http: HttpClient) { }

  getProducts(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Products/GetProductByCategory`);
  }

  getCategories(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/Category/all`);
  }

  getProductById(productId: number): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/Products/GetProductByCategory/${productId}`);
  }

  addProduct(product: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/Products/AddEditProduct`, product);
  }

  editProduct(product: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/Products/AddEditProduct`, product);
  }

  deleteProduct(productId: number): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/Products/Delete/${productId}`);
  }
}
