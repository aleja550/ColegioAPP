import { Component, Injectable, OnInit } from '@angular/core';
import { FormGroupDirective } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Estudiante } from 'src/app/models/estudiante';
import { EstudiantesService } from 'src/app/services/estudiantes.service';
import { CursosService } from 'src/app/services/cursos.service';
import { Curso } from 'src/app/models/curso';

@Component({
  selector: 'app-modal-crear',
  templateUrl: './modal-crear.component.html'
})

@Injectable({
  providedIn: 'root'
})
export class ModalCrearComponent implements OnInit {
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

  constructor(private _estudiantesService: EstudiantesService, private toastr: ToastrService, private _cursoService: CursosService) { }

  ngOnInit(): void {
  }

  validate(formDirective: FormGroupDirective){
    var form = document.getElementsByClassName('needs-validation')[0] as HTMLFormElement;
    if (form.checkValidity() === false) {
      event.preventDefault();
      event.stopPropagation();
    } else{
      this.agregarEstudiante();
      formDirective.reset();
    }
    form.classList.add('was-validated');
  }

  agregarEstudiante(){
    let estudiante = new Estudiante(0, this.tipoId, this.numeroId, this.nombre1, this.nombre2, this.apellido1, this.apellido2, this.email, this.celular, this.direccion, this.ciudad);

    this._estudiantesService.createEstudiante(estudiante)
    .subscribe(res => {
      this.toastr.success('El estudiante se ha agregado correctamente');
    }, error => {
      this.toastr.error(error);
    });
  }

  selectChangeHandler(event){
    this.tipoId = event.target.value;  
  }

  getCursos(){
    this._cursoService.getCursos().subscribe(cursosArray => {
        this.cursos = cursosArray;
      }
    );
  }
}
