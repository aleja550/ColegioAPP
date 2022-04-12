import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpParams, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Estudiante } from '../models/estudiante';
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class EstudiantesService {
    
    constructor(private http: HttpClient){ }

    getEstudiantes(): Observable<Estudiante[]>{
        return this.http.get<Estudiante[]>('https://localhost:44320/Estudiante')
        .pipe( map( data => {
            return data;
        }));
    }

    createEstudiante(estudiante: Estudiante): Observable<Estudiante> {
        let res = this.http.post<Estudiante>('https://localhost:44320/Estudiante', estudiante, {observe: 'response'})
        .pipe(catchError(error => throwError(`Ocurrio un error creando el estudiante. Error ${error.status}`)));;

        return res.pipe( map(data => {
            return data.body;
        }));
    }

    eliminarEstudiante(id: number) {
       let res = this.http.delete(`https://localhost:44320/Estudiante/Eliminar/${id}`);

       return res;
    }
}