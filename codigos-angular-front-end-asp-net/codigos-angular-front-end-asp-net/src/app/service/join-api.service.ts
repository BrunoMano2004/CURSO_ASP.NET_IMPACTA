import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()

export class JoinApiService {

  apiUrlBase: string = 'http://localhost:5205/api/Join'

  constructor(private httpReq: HttpClient) { }

  cruzamentoDominio = {
    headers: new HttpHeaders({
      'Content-Type' : 'application/json'
    })
  }

  recTodosOsRegistros(): Observable<any>{
    return this.httpReq.get<any>(this.apiUrlBase+'/GetJoinTodosOsCursos')
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
