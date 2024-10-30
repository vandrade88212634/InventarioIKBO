export interface responseProductoFecha {
    isSuccess: boolean | null;
    messages: string | null;
    result: []
}

export interface productoFecha {
    idProductoFecha: number;
    idproducto: string;
    fechaVence: any;
    saldo: number;
    
}