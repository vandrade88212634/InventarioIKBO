import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment.prod';
import { producto, responseProducto } from '../../core/models/producto.model';
import { Observable, catchError, map } from 'rxjs';


@Injectable({
    providedIn: 'root',
})
export class ProductoService {

    constructor(private http: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };

    apiUrl = environment.urlBase;
    router: any;

    
   
    InsertProducto(data: any) {//revisar back
        debugger;
        return this.http.post<any>(`${this.apiUrl}InventarioIKBO/InsertProducto`, JSON.stringify(data), this.httpOptions).pipe(
            map((response) => {
                return response;
            }),
            catchError((error) => {
                console.error('Error en la solicitud:', error);
                throw error;
            })
        );
    }

   
    

   
}