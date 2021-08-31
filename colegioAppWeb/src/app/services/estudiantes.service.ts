import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
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

    createEstudiante(estudiante: Estudiante): Observable<any | HttpResponse<any>> {
        let res = this.http.post<any>('https://localhost:44320/Estudiante', estudiante, {observe: 'response'});

        return res.pipe(
            catchError(error => throwError(`Ocurrio un error creando el estudiante. Error ${error.status}`)),
        );
    }
}