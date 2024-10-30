import { CanActivateFn, Router } from '@angular/router';
import { AuthCacheService } from '../services/chache/auth/authCache.service';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = async (route, state) => {

  const authCacheService = inject(AuthCacheService);
  const router = inject(Router);

  const isAuthenticated = await authCacheService.obtenerUsuarioAutenticado();
  console.log(isAuthenticated);
  if (isAuthenticated) {
    return true;
  } else {
    router.navigate(['/login']);
    return false
  }
};

