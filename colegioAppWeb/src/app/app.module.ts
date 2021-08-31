import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { SearchComponent } from './components/search/search.component';
import { EstudianteComponent } from './components/estudiante/estudiante.component';
import { ModalCrearComponent } from './components/modal-crear/modal-crear.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

//Rutas
import {APP_ROUTING} from './app.routes';

//Servicios
import { EstudiantesService } from './services/estudiantes.service';
import { CursosService } from 'src/app/services/cursos.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SearchComponent,
    EstudianteComponent,
    NavbarComponent,
    ModalCrearComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    FormsModule,
    APP_ROUTING,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    EstudiantesService,
    CursosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
