import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

interface LoginResponse {
  token: string;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(private http: HttpClient) {}

  login(email: string, password: string): Observable<LoginResponse> {
    // Replace apiUrl with your backend API URL
    const apiUrl = 'https://localhost:7043/api';
    return this.http.post<LoginResponse>(`${apiUrl}/Login/Login`, { email, password });
  }
  getToken(): string | null {
    let token = localStorage.getItem('token');
    if (token === null) token = sessionStorage.getItem('token');
    return token;
  }
}
