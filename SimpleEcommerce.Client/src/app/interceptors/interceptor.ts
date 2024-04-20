import { Injectable } from '@angular/core';
import { LoginService } from '../services/login.service';

import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {  finalize, map, mergeMap } from 'rxjs/operators';

@Injectable()
export class Interceptor implements HttpInterceptor {
  constructor()
{ }

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.loginService.getToken();
    if (token != null && request.url) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
    return next.handle(request).pipe(
   
      map((res: any) => {
        if (
          (request.method === 'PATCH' ||
            request.method === 'PUT' ||
            request.method === 'POST') &&
          res &&
          res.status === 200
        )
         
        return res;
      }),
      finalize(() => {
      })
    );
  }

}
