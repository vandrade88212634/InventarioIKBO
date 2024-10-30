import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment.prod';
import { responseLogin } from '../../core/models/auth.model';
import { Observable, catchError, map } from 'rxjs';
import { AuthCacheService } from '../chache/auth/authCache.service';
import { Router } from '@angular/router';

export interface responseHttp {
  isSuccess: boolean | null;
  messages: string | null;
  result: any;
}
@Injectable({
  providedIn: 'root',
})
export class AuthService {

  constructor(
    private route : Router,
    private http: HttpClient, 
    private AuthCaheSrv: AuthCacheService) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  apiUrl = environment.urlBase;
  router: any;

  login(email: string, password: string): Observable<responseLogin> {

    const data = { user: email, password: password };

    return this.http.post<responseLogin>(`${this.apiUrl}Login/Autentication`, JSON.stringify(data), this.httpOptions).pipe(
      map((result) => {
       
        return result;
      }),
      catchError((error) => {
        console.error('Error en la solicitud:', error);
        // Puedes manejar el error aquí si es necesario
        throw error; // Lanza el error en lugar de retornar 'false'
      })
    );
  }

  InactivateUser(document: string): Observable<responseLogin> {

    return this.http.get<responseLogin>(`${this.apiUrl}Usuarios/InactivateUser/${document}`, this.httpOptions).pipe(
      map((result) => {
        return result;
      }),
      catchError((error) => {
        console.error('Error en la solicitud:', error);
        // Puedes manejar el error aquí si es necesario
        throw error; // Lanza el error en lugar de retornar 'false'
      })
    );
  }

  logout(){
    this.AuthCaheSrv.borrarCache().then( data=>{
       this.route.navigate(['/login'])
      }
    );
  }

  BuscaPermiso(idRol:number, idPermiso: number){
    return this.http
      .get<responseHttp>(
        `${this.apiUrl}Permisos/GetPermisoUsuario/${idRol}/${idPermiso}`
      )
      .pipe(
        map((dataResult) => {
          return dataResult;
        })
      );
  }

}