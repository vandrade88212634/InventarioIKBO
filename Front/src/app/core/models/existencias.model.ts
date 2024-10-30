export interface responseExistencias {
    isSuccess: boolean | null;
    messages: string | null;
    result: []
}

export interface existencias {
    
    idProducto: number;
    nombre: string;
    fechaVence:string;
    idEstado: number;
    nombreEstado:string ;
    
    saldo: number;
    
      
     isSucess: boolean,
     message: string;

}