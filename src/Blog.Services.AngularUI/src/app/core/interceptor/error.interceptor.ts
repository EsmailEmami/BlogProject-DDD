import {Injectable, Injector} from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS,
  HttpErrorResponse
} from '@angular/common/http';
import {catchError, Observable, retry, throwError} from 'rxjs';
import {ErrorService} from "../services/error-handling/error.service";
import {NotificationService} from "../services/notification.service";

@Injectable()
export class ServerErrorInterceptor implements HttpInterceptor {

  constructor(
    private injector: Injector) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let errorResult: string[];
    const errorService = this.injector.get(ErrorService);
    const notifier = this.injector.get(NotificationService);

    return next.handle(request)
      .pipe(
        catchError((error: HttpErrorResponse) => {
          errorResult = errorService.getServerErrorMessage(error).error;

          debugger;

          if (errorResult.length > 0) {
            errorResult.forEach(value => {
              notifier.showError(value);
            })
          }

          return throwError(error);
        })
      )
  }
}

export const ErrorInterceptorProvider = {
  provide: HTTP_INTERCEPTORS,
  useClass: ServerErrorInterceptor,
  multi: true
};
