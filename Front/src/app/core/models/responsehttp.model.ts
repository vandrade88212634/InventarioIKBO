export interface ciudades {
  isSuccess: boolean | null;
  messages:  string | null;
  result: [
    {
      idCiudad: number | null;
      idDepartamento:  number | null;
      codigoDANECiudad:  number | null;
      nombre: string | null;
    }
  ]
}

export interface tipoDocumento {
  isSuccess: boolean | null;
  messages:  string | null;
  result: [
    {
      id: number | null;
      descripcion: string | null;
    }
  ]
}


