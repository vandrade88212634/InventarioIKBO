import { HttpInterceptorFn } from '@angular/common/http';

export const TokenInterceptor: HttpInterceptorFn = (req, next) => {
  const authToken = 'AAS3245678987654fghjgfdfghj';

  // Clone the request and add the authorization header
  const authReq = req.clone({
    setHeaders: {
    }
  });

  if (req.method === 'POST' && authToken) {
    // Clone the request and add the authorization header only for POST requests
    const authReqtoken = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authToken}`
      }
    });

    // Pass the cloned request with the updated header to the next handler
    return next(authReqtoken);
  } else {
    // Pass the cloned request with the updated header to the next handler
  return next(authReq);
  }

  
};