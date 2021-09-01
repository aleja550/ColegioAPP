export class EstudianteCurso{
    id: number;
    idEstudiante : number;
    idCurso : number;
    notaFinal?: number;
   
    constructor(id:number, idEstudiante:number, idCurso:number, notaFinal:number) { 
        this.id = id; 
        this.idEstudiante = idEstudiante; 
        this.idCurso = idCurso; 
        this.notaFinal = notaFinal; 
     } 
}