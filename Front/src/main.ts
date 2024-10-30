/// <reference types="@angular/localize" />

import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app.component';
import { environment } from './app/environment/environment';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));

 /*  if ('serviceWorker' in navigator && environment.production) {
    window.addEventListener('load', () => {
      navigator.serviceWorker.register('/sw.js').then(registration => {
        console.log('ServiceWorker registrado con alcance:', registration.scope);
      }, err => {
        console.error('Error al registrar el ServiceWorker:', err);
      });
    });
  } */