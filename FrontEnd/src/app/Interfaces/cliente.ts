export interface Cliente {
    id: number;
    nombre: string;
    apellido: string;
    email: string;
    fechaDeNacimiento: Date;
    activo:boolean;
    direccion:string;
    telefono:string
}
