import { Component, Input } from '@angular/core';

import { CursoApiService } from 'src/app/service/curso-api.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-inserir-curso',
  templateUrl: './inserir-curso.component.html',
  styleUrls: ['./inserir-curso.component.css']
})
export class InserirCursoComponent {
  tituloComp: string = 'Inserir Cadastro'

  @Input() cadastroInserido = {
    cursoNome: '',
    cursoMensalidade: '',
    estudanteId: 0,
    estudanteRA: 0
  }

  constructor(
    private cursoApi: CursoApiService,
    private roteador: Router
  ){}

  inserirUmCadastro(): any{
    this.cursoApi.inserirRegistro(this.cadastroInserido).subscribe(() =>{
      this.roteador.navigate(['/listarCurso'])
    })
  }
}
