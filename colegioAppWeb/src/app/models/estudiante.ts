export class Estudiante{
    id: number;
    tipoIdentificacion : string;
    identificacion : string;
    nombre1: string;
    nombre2: string;
    apellido1: string;
    apellido2: string;
    email: string;
    celular: string;
    direccion: string;
    ciudad: string;

    constructor(id:number, tipoIdentificacion:string, identificacion:string, nombre1:string, nombre2:string, apellido1:string, apellido2:string, 
        email:string, celular:string,direccion:string, ciudad:string) { 
        this.id = id; 
        this.tipoIdentificacion = tipoIdentificacion; 
        this.identificacion = identificacion; 
        this.nombre1 = nombre1; 
        this.nombre2 = nombre2; 
        this.apellido1 = apellido1; 
        this.apellido2 = apellido2; 
        this.email = email; 
        this.celular = celular; 
        this.direccion = direccion; 
        this.ciudad = ciudad; 
     } 
}