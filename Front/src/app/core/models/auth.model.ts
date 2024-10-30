export interface UserResponse {

}

export interface UserCredentials {
  username: string;
  password: string;
}

export interface responseFormLogin {
  firstName: string | null;
  username: string | null;
  lastname: string | null;
  accessRol: string | null;
  isSuccess: boolean | null;
  messages: string | null;
  activo: boolean | null;
}

export interface reponseAuth {
  isSuccess: boolean;
  messages: string;
  idUser: number;
  validado: number;
  activo: number;
  desActivo: string;
  numeroDocumento: number,
  correoElectronico: string;
  idCiudad?: number;
  idOrganizacion?: number;
  idTipoDocumento?: number;
  rols: string,
  accesos: [],
  oec: {
    idOrganizacion: number,
    razonSocial: string;
    direccionAtributo1: string;
    direccionAtributo2: string;
    direccionAtributo3: string;
    direccionAtributo4: string;
    direccionAtributo5: string;
    direccionAtributo6: string;
    direccionAtributo7: string;
    direccionAtributo8: string;
    direccionAtributo9: string;
    direccionGenerada: string;
    idCiudad: number;
    idDepartamento: null,
    idTipoOrganizacion: null,
    acreditacionAutorizacion: number;
    fechaCreacion: null,
    usuarioCreacion: string;
    fechaModificacion: null,
    usuarioModificacion: string;
    numeroDocumento: null
  }

}

export interface requestLoginForm {
  username: string;
  password: string;
}


export interface responseLogin {
  isSuccess: boolean | null;
  messages: string | null;
  result: {
    token: string | null;
    nombre: string | null;
    messages: string | null;
    idUser: number | null;
    isSuccess: true,
    validado: number,
    activo: number,
    desActivo: number | null,
    correoElectronico: string,
    cedula: number
  }
}

export interface responsePreRegister {
  isSuccess: boolean | null;
  messages: string | null;
  result: {
    idUsuario: number | null;
    fechaRegistro: string | null;
    nombres: string | null;
    apellidos: string | null;
    numeroDocumento: number | null;
    correoElectronico: string | null;
    idCiudad: number | null;
    estado: number | null;
    descEstado: number | null;
    autorizoCorreo: boolean | null;
    autorizoTratamiento: boolean | null;
    validado: boolean | null;
    contraseña: string | null;
    idOrganizacion: number | null;
    messages: string | null;
    isSuccess: boolean | null;
  }
}

export interface responseRegister {
  isSuccess: boolean;
  messages: string;
  result: {
    idUsuario: number | null;
    fechaRegistro: string | null;
    nombres: string | null;
    apellidos: string | null;
    numeroDocumento: number | null;
    correoElectronico: string | null;
    idCiudad: number | null;
    estado: number | null;
    descEstado: number | null;
    autorizoCorreo: boolean | null;
    autorizoTratamiento: boolean | null;
    validado: boolean | null;
    contraseña: string | null;
    idOrganizacion: number | null;
    messages: string | null;
    isSuccess: boolean | null;
  }
}

export interface formRegisterUser {
  idUsuario: number,
  fechaRegistro: string,
  nombres: string,
  apellidos: string,
  idTipoDocumento: number,
  numeroDocumento: number,
  correoElectronico: string,
  idCiudad: number,
  estado: boolean,
  descEstado: string,
  autorizoCorreo: boolean,
  autorizoTratamiento: boolean,
  validado: boolean,
  contraseña: string,
  idOrganizacion: number,
  messages: string,
  isSuccess: true
}

export interface requestChangePassword {
  idUsuario: number,
  password?: string,
  newPassword: string,
  reNewPasword: string
}


