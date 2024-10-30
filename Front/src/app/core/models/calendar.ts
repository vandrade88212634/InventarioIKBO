export interface activities {
    codigo: number,
    descripcion: string,
    estCodigo: number,
    descEstrategia: string,
    iniCodigo: number,
    descIniciativa: string,
    accCodigo: number,
    descAccion: string,
    regCodigo: number,
    descRegional: string,
    fecha: Date,
    munCodigo: number,
    descMunicipio: string,
    sector: string,
    esaCodigo: number,
    descEstado:string,
    color: string,
    tpoCodigo: number,
    descTipo: string,
    duracion: number,
    telefono: 3002561475,
    personacontacto: string,
    participantes: number,
    reqEvidencia: boolean,
    observacion: string,
    fechaRegistro?: string,
    fechaModificacion?: null,
    usuarioRegistro?:  string,
    usuarioModificacion?: null,
    mesage?: string,
    isSucess?: true,
    importancia: number,
    temas: any[];
    compromisos?: any,
    evidencias?: any
};

export interface EvidenciaActividad {
    codigo: number,
    nombre: string,
    url: string,
    actCodigo: number,
    base64: string,
    fechaRegistro: string,
    fechaModificacion: string,
    usuarioRegistro: string,
    usuarioModificacion: string,
    isSucess?: boolean,
    message?: string,
    type?:string
}

export interface  compromisos {
    codigo: number,
    descripcion: string,
    actCodigo: number,
    estado: number,
    fechaCumplimiento: string
    fechaRegistro:string,
    fechaModificacion: string,
    usuarioRegistro: string,
    usuarioModificacion: string,
    isSucess?: boolean,
    message?: string
}

