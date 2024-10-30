import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment.prod';
import { producto, responseProducto } from '../../core/models/producto.model';
import { Observable, catchError, map } from 'rxjs';
import { responseProductoFecha } from '../../core/models/productofecha.model';


@Injectable({
    providedIn: 'root',
})
export class SalidaService {

    constructor(private http: HttpClient) { }

    httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        }),
    };

    apiUrl = environment.urlBase;
    router: any;

    
   
    InsertSalida(data: any) {//revisar back
        return this.http.post<any>(`${this.apiUrl}InventarioIKBO/InsertSalida`, JSON.stringify(data), this.httpOptions).pipe(
            map((response) => {
                return response;
            }),
            catchError((error) => {
                console.error('Error en la solicitud:', error);
                throw error;
            })
        );
    }

    GetAllProductos(): Observable<responseProducto> {

        return this.http.get<responseProducto>(`${this.apiUrl}InventarioIKBO/GetAllProductos`, this.httpOptions).pipe(
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


    GetAllProductosFechaByIdProducto(IdProducto:number): Observable<responseProductoFecha> {//revisar back
        return this.http.get<responseProductoFecha>(`${this.apiUrl}InventarioIKBO/GetAllProductoFechaByIdProducto/${IdProducto}`,this.httpOptions).pipe(
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