import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Curso } from '../models/curso';
import { catchError, map } from 'rxjs/operators';

@Injectable()
export class CursosService {
    
    constructor(private http: HttpClient){ }

    getCursos(): Observable<Curso[]>{
        return this.http.get<Curso[]>('https://localhost:44320/Curso')
        .pipe( map( data => {
            return data;
        }));
    }   
}