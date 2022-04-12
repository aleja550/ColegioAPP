import { Component, OnInit } from '@angular/core';
import { Estudiante } from 'src/app/models/estudiante';
import { EstudiantesService } from '../../services/estudiantes.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-estudiante',
  templateUrl: './estudiante.component.html'
})
export class EstudianteComponent implements OnInit {

  estudiantes: Estudiante[] = [];

  constructor(private _estudiantesService: EstudiantesService, private toastr: ToastrService,) { }
  
  ngOnInit() {
    this.getEstudiantes();
  }

  getEstudiantes(){
    this._estudiantesService.getEstudiantes().subscribe(estudiantesArray => {
        this.estudiantes = estudiantesArray;
      }
    );
  }

  eliminarEstudiante(id: number): void {
    this._estudiantesService.eliminarEstudiante(id).subscribe(result => {
      if(result == null) {
        this.toastr.success('El estudiante se ha eliminado correctamente');
        window.location.reload();
      }
    });
  }
}