import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()

export class JoinApiEstudanteService {

  apiUrlBase: string = 'http://localhost:5205/api/Join'

  constructor(private httpReq: HttpClient) { }

  cruzamentoDominio = {
    headers: new HttpHeaders({
      'Content-Type' : 'application/json'
    })
  }

  recTodosOsEstudantes(): Observable<any>{
    return this.httpReq.get<any>(this.apiUrlBase+'/GetJoinTodosOsEstudantes')
    .pipe(
      retry(1),
      catchError(this.observarBug)
    )
  }

  recUmRegistro(id: any): Observable<any>{
    return this.httpReq.get<any>(this.apiUrlBase+'/buscaFiltradaEstudante/'+ id)
    .pipe(
      retry(1),
      catchError(this.observarBug)
    )
  }

  observarBug(bug: any){
    let infosBug: any = '' 

    if(bug.error instanceof ErrorEvent){
        infosBug = bug.error.message
    }else{
      infosBug = `Codigo do erro: ${bug.status}\nMensagem do erro: ${bug.message}`
    }
    alert(infosBug)

    return throwError(() => infosBug)
  }
}
