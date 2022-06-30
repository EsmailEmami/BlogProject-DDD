import {Injectable, Injector} from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS,
  HttpErrorResponse
} from '@angular/common/http';
import {catchError, Observable, throwError} from 'rxjs';
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

          try {
            errorResult.forEach(value => {
              notifier.showError(value);
            });
          } catch {
            notifier.showError('متاسفانه مشکلی غیر منتظره پیش آمده است. لطفا با پشتیبانی تماس بگیرید');
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
