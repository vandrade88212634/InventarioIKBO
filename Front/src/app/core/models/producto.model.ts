export interface responseProducto {
    isSuccess: boolean | null;
    messages: string | null;
    result: []
}

export interface producto {
    idProducto:number;
    nombre: string;
    isSucess: boolean;
    message: string;
    
    
}