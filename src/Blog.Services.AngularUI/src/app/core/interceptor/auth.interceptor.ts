import {Injectable} from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpInterceptor,
  HttpEvent,
  HTTP_INTERCEPTORS,
  HttpErrorResponse,
} from '@angular/common/http';
import {Observable, tap} from 'rxjs';
import {TokenStorageService} from "../token-storage.service";

const TOKEN_HEADER_KEY = 'Authorization';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private token: TokenStorageService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const token = this.token.getToken();

    if (token) {
      request = request.clone({
        headers: request.headers.set(TOKEN_HEADER_KEY, 'Bearer ' + token)
      });
    }

    return next.handle(request).pipe(tap(() => {
      },
      (err: any) => {
        if (err instanceof HttpErrorResponse &&
          err.status !== 401) {
          return;
        }
      }));
  }
}

export const authInterceptorProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }
];
