import { Component, Injectable, OnInit, resolveForwardRef } from '@angular/core';
import { FormGroupDirective } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Estudiante } from 'src/app/models/estudiante';
import { EstudiantesService } from 'src/app/services/estudiantes.service';
import { CursosService } from 'src/app/services/cursos.service';
import { EstudianteCursosService} from 'src/app/services/estudiantesCursos.service';
import { Curso } from 'src/app/models/curso';
import { EstudianteCurso } from 'src/app/models/estudianteCurso';

@Component({
  selector: 'app-modal-crear',
  templateUrl: './modal-crear.component.html'
})

@Injectable({
  providedIn: 'root'
})
export class ModalCrearComponent implements OnInit {
  estudiante: Estudiante;
  cursos: Curso[]= [];
  tipoId: string = '';
  numeroId: string = '';
  nombre1: string = ''; 
  nombre2: string = '';
  apellido1: string = '';
  apellido2: string = '';
  email: string = '';
  celular: string = '';
  direccion: string = '';
  ciudad: string = '';
  cursoId: number = 0;
  estadoGestion: boolean = true;

  constructor(private _estudiantesService: EstudiantesService, private toastr: ToastrService, private _cursoService: CursosService, private _estudianteCursoService: EstudianteCursosService) { }

  ngOnInit(): void {

  }

  validate(formDirective: FormGroupDirective){
    var form = document.getElementsByClassName('needs-validation')[0] as HTMLFormElement;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    } else{
      this.agregarEstudiante();
    }
    form.classList.add('was-validated');
  }

  agregarEstudiante(){
    let student = new Estudiante(0, this.tipoId, this.numeroId, this.nombre1, this.nombre2, this.apellido1, this.apellido2, this.email, this.celular, this.direccion, this.ciudad);

    this._estudiantesService.createEstudiante(student)
    .subscribe(res => {
      this.estadoGestion = false;
      this.estudiante = res;
      this.toastr.success('El estudiante se ha agregado correctamente');
    }, error => {
      this.toastr.error(error);
    });
  }

  selectChangeHandler(event){
    if(event.target.value == 0 || event.target.value == ''){
      return;
    }
    this.tipoId = event.target.value;  
  }

  getCursos(){
    this._cursoService.getCursos().subscribe(cursosArray => {
        this.cursos = cursosArray;
      }
    );
  }

  selectCursos(event){
    if(event.target.value == 0 || event.target.value == ''){
      return;
    }

    this.cursoId = event.target.value;  
  }

  asociarCurso(){
    let estudianteCurso = new EstudianteCurso(0, this.estudiante.id, this.cursoId, 0.0);

    this._estudianteCursoService.createEstudianteCurso(estudianteCurso)
    .subscribe(res => {
      this.toastr.success('El estudiante se ha asociado correctamente al curso.');
    }, error => {
      this.toastr.error(error);
    });
  }
}
