import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { EstudianteCurso } from '../models/estudianteCurso';

@Injectable()
export class EstudianteCursosService {
    
    constructor(private http: HttpClient){ }

    createEstudianteCurso(estudianteCurso: EstudianteCurso): Observable<any | HttpResponse<any>> {
        let res = this.http.post<any>('https://localhost:44320/EstudianteCurso', estudianteCurso, {observe: 'response'});

        return res.pipe(
            catchError(error => throwError(`Ocurrio un error creando la asociacion del estudiante con el curso ${estudianteCurso.idCurso}. Error ${error.status}`)),
        );
    }
}