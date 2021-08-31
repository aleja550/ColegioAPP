import { Component, OnInit } from '@angular/core';
import { Estudiante } from 'src/app/models/estudiante';
import { EstudiantesService } from '../../services/estudiantes.service';

@Component({
  selector: 'app-estudiante',
  templateUrl: './estudiante.component.html'
})
export class EstudianteComponent implements OnInit {

  estudiantes: Estudiante[] = [];

  constructor(private _estudiantesService: EstudiantesService) { }
  
  ngOnInit() {
    this.getEstudiantes();
  }

  getEstudiantes(){
    this._estudiantesService.getEstudiantes().subscribe(estudiantesArray => {
        this.estudiantes = estudiantesArray;
      }
    );
  }
}