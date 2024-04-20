import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';



@Injectable({
    providedIn: 'root',
})
export class ProductService {


    private apiUrl = 'https://localhost:7043/api';

    constructor(private http: HttpClient) { }

    getCategories(): Observable<any[]> {
        return this.http.get<any[]>(`${this.apiUrl}/Category/all/`);
    }
    addProduct(formData: any) {
        debugger;
        return this.http.post<any>(`${this.apiUrl}/Products/AddEditProduct`, formData);
    }

    uploadImage(file: File): Observable<any> {
        debugger;
        const formData: FormData = new FormData();
        formData.append('file', file);

        const headers = new HttpHeaders();
        headers.append('Content-Type', 'multipart/form-data');
        headers.append('Accept', 'application/json');

        return this.http.post<any>(`${this.apiUrl}/Products/uploadImage`, formData, { headers });
    }



}
