export interface Cliente {
    usuarioId: number;
    nombre: string;
    apellido: string;
    correoElectronico: string;
    fechaDeNacimiento: Date;
    activo:boolean;
    direccion:string;
    telefono:string
}
