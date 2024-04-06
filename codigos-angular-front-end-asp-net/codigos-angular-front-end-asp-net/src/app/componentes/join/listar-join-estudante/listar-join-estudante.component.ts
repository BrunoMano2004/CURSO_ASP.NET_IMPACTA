import { Component, OnInit } from '@angular/core';
import { JoinApiEstudanteService } from 'src/app/service/join-api-estudante.service';

@Component({
  selector: 'app-listar-join-estudante',
  templateUrl: './listar-join-estudante.component.html',
  styleUrls: ['./listar-join-estudante.component.css']
})
export class ListarJoinEstudanteComponent implements OnInit {
  tituloComp: string = 'Listar Join Estudante'

  constructor(
    private joinApiEstudante: JoinApiEstudanteService
  ){}

  listaDeJoinEstudante: any = []

  ngOnInit(): void {
    this.exibirListaEstudantes()
  }

  exibirListaEstudantes(): void{
    this.joinApiEstudante.recTodosOsEstudantes().subscribe((chegandoDados: any) =>{
      this.listaDeJoinEstudante = chegandoDados
    })
  }
}
