import { Component, OnInit } from '@angular/core';

import { CursoApiService } from 'src/app/service/curso-api.service';

import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-atualizar-curso',
  templateUrl: './atualizar-curso.component.html',
  styleUrls: ['./atualizar-curso.component.css']
})
export class AtualizarCursoComponent {
  tituloComp: string = 'Atualizar Cadastro'

  dadosAtuaisCurso: any = {}

  constructor(
    private cursoApi: CursoApiService,
    private roteador: Router,
    private copiandoRota: ActivatedRoute
  ){}

  rotaCopiada: any = this.copiandoRota.snapshot.params['id']

  ngOnInit(): void {
    this.cursoApi.recUmRegistro(this.rotaCopiada).subscribe((dadosRec: any) =>{
      this.dadosAtuaisCurso = dadosRec
    })
  }

  atualizarDadosCurso(): void{
    this.cursoApi.atualizarRegistro(this.dadosAtuaisCurso.cursoId, this.dadosAtuaisCurso).subscribe(() =>{
      this.roteador.navigate(['/listarCurso'])
    })
  }
}
