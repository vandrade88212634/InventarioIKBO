import { ApplicationConfig, NgModule, isDevMode } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideServiceWorker } from '@angular/service-worker';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';

import { withInterceptors } from '@angular/common/http';
import { TokenInterceptor } from './core/interceptors/token';

export const appConfig: ApplicationConfig = {
  providers: [MatDialog, provideRouter(routes), provideClientHydration(), provideHttpClient(), provideServiceWorker('ngsw-worker.js', {
    enabled: !isDevMode(),
    registrationStrategy: 'registerWhenStable:30000'
  }), provideAnimationsAsync(),
    provideHttpClient(withInterceptors([TokenInterceptor]))]
};
