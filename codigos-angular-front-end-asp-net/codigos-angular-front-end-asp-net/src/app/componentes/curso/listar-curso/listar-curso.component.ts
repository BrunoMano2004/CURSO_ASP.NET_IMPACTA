import { Component, OnInit } from '@angular/core';

import { CursoApiService } from 'src/app/service/curso-api.service';

@Component({
  selector: 'app-listar-curso',
  templateUrl: './listar-curso.component.html',
  styleUrls: ['./listar-curso.component.css']
})
export class ListarCursoComponent {
  tituloComp: string = 'Lista de Cursos'

  constructor(
    private cursoApi: CursoApiService
  ){}

  listaDeCursos: any = []

  ngOnInit(): void {
    this.exibirListaCursos()
  }

  exibirListaCursos(): void{
    this.cursoApi.recTodosOsRegistros().subscribe((chegandoDados: any) =>{
      this.listaDeCursos = chegandoDados
    })
  }

  excluirCadastroCurso(id: any): any{
    if(confirm('Deseja, realmente, excluir este cadastro?')){
      this.cursoApi.exclusaoRegistro(id).subscribe(() => {
        this.exibirListaCursos()
      })
    }
  }
}
