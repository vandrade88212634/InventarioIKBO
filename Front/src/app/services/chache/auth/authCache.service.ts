import { Injectable } from '@angular/core';
import { SwUpdate } from '@angular/service-worker';

export interface user {
  id: number;
  name: string;
  loggedIn: boolean;
  type: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthCacheService {
  private cacheInitialized: boolean = false;

  constructor(private swUpdate: SwUpdate) {
    //this.initializeCache();
  }

  private async initializeCache() {
    if (this.swUpdate.isEnabled) {
      const cache = await caches.open('app-cache');
      await cache.put('usuario-autenticado', new Response(JSON.stringify({ loggedIn: true, userType: 'admin' })));
      this.cacheInitialized = true; // Marcar la inicialización del caché como completada
    }
  }

  async obtenerUsuarioAutenticado(): Promise<any> {
   /*
    if (!this.cacheInitialized) {
      await this.initializeCache(); // Esperar a que se complete la inicialización del caché
    }
    const cache = await caches.open('app-cache');
    const cachedData = await cache.match('usuario-autenticado');
    if (cachedData) {
      return await cachedData.json();
    }
      */
    return null;
  }

  async guardarDatosUsuario(userData: any): Promise<void> {
    /*
    if (!this.cacheInitialized) {
      //await this.initializeCache(); // Esperar a que se complete la inicialización del caché
    }
    const cache = await caches.open('app-cache');
    const response = new Response(JSON.stringify(userData));
    await cache.put('usuario-autenticado', response);
    */
  }

  async borrarCache(): Promise<void> {
    if (this.swUpdate.isEnabled) {
      await caches.delete('app-cache');
    }
  }
}
