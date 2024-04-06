import { Component, OnInit } from '@angular/core';
import { JoinApiService } from 'src/app/service/join-api.service';

@Component({
  selector: 'app-listar-join',
  templateUrl: './listar-join.component.html',
  styleUrls: ['./listar-join.component.css']
})
export class ListarJoinComponent implements OnInit {
  tituloComp: string = 'Listar Join'

  constructor(
    private joinApi: JoinApiService
  ){}

  listaDeJoin: any = []

  ngOnInit(): void {
    this.exibirListaCursos()
  }

  exibirListaCursos(): void{
    this.joinApi.recTodosOsRegistros().subscribe((chegandoDados: any) =>{
      this.listaDeJoin = chegandoDados
    })
  }
}
