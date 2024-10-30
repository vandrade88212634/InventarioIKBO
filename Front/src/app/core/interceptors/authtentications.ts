import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Observable, timer } from 'rxjs';
import { switchMap, take, tap } from 'rxjs/operators';

@Injectable()
export class InactivityTimerInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // Realiza la solicitud original
    return next.handle(req).pipe(
      // Realiza acciones después de una solicitud exitosa
      tap(() => {
        // Reinicia el temporizador de inactividad cada vez que hay una solicitud exitosa
        
      })
    );
  }
}
