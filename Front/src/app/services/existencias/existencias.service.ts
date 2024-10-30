import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment.prod';
import { producto, responseProducto } from '../../core/models/producto.model';
import { Observable, catchError, map } from 'rxjs';
import { responseProductoFecha } from '../../core/models/productofecha.model';


@Injectable({
    providedIn: 'root',
})
export class ExistenciasService {

    constructor(private http: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };

    apiUrl = environment.urlBase;
    router: any;

    
   
    GetAllExistencias(data: any) {//revisar back
        return this.http.post<any>(`${this.apiUrl}InventarioIKBO/Existencias`, JSON.stringify(data), this.httpOptions).pipe(
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