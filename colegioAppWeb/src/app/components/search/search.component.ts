import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Estudiante } from 'src/app/models/estudiante';
import { EstudiantesService } from 'src/app/services/estudiantes.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {

  estudiantes: Estudiante[] = [];
  palabraClave: string;

  constructor( private activatedRoute: ActivatedRoute, private _estudianteService: EstudiantesService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe( params => {
      this.getEstudiantes( params['termino'] );
    });
  }
 
   getEstudiantes( termino:string) {
    this._estudianteService.getEstudiantes().subscribe(estudiantesArray => {
      let estudiantesArr:Estudiante[] = estudiantesArray;
      this.filterEstudiantes(termino, estudiantesArr);
    });
  }

  filterEstudiantes( termino:string, estudiantesArr:Estudiante[]) {
    this.estudiantes = [];
    termino = termino.toLowerCase();
    this.palabraClave = termino;
    
    for( let i = 0; i < estudiantesArr.length; i ++ ){

      let student = estudiantesArr[i];

      let nombre = student.nombre1.toLowerCase();
      let segundoNombre = student.nombre2.toLowerCase();
      let identificacion = student.identificacion;
      let apellido = student.apellido1.toLowerCase();
      let email = student.email.toLocaleLowerCase();

      
      if( nombre.includes( termino ) || segundoNombre.includes( termino ) || identificacion.includes( termino ) 
          || apellido.includes( termino) || email.includes( termino ) ) 
      {
        student.id = i;
        this.estudiantes.push( student );
      }
    }
  }
}
