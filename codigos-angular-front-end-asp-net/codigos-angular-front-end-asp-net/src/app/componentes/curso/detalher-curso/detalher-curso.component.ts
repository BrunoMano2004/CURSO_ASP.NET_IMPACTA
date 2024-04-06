import { Component, OnInit } from '@angular/core';

import { CursoApiService } from 'src/app/service/curso-api.service';

import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalher-curso',
  templateUrl: './detalher-curso.component.html',
  styleUrls: ['./detalher-curso.component.css']
})
export class DetalherCursoComponent {
  tituloComp: string = 'Detalhes de informações do estudante'

  cadastroUnico: any = {}

  constructor(
    private cursoApi: CursoApiService,
    private roteador: Router,
    private copiandoRota: ActivatedRoute
  ){}

  rotaCopiada: any = this.copiandoRota.snapshot.params['id']

  ngOnInit(): void {
    this.acessandoUmCadastro()
  }

  acessandoUmCadastro(): void{
    this.cursoApi.recUmRegistro(this.rotaCopiada).subscribe((dadosChegaram:{}) =>{
      this.cadastroUnico = dadosChegaram
    })
  }

  excluirCadastroCurso(id: any): any{
    if(confirm('Deseja, realmente, excluir este cadastro?')){
      this.cursoApi.exclusaoRegistro(id).subscribe(() => {
        this.roteador.navigate(['/listarCurso'])
      })
    }
  }
}
