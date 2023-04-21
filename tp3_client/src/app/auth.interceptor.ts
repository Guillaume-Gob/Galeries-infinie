import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log("Sa marche")
    request = request.clone({
        setHeaders: {
         'Authorization' : 'Bearer ' + localStorage.getItem("token")

        }



    })
    
    console.log(request);
    return next.handle(request);
  }
}
