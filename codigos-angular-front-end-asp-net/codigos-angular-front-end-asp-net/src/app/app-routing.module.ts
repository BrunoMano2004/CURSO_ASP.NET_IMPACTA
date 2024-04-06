import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// importando os componentes
import { InserirCadastroComponent } from './componentes/estudante/inserir-cadastro/inserir-cadastro.component';
import { AtualizarCadastroComponent } from './componentes/estudante/atualizar-cadastro/atualizar-cadastro.component';
import { ListarCadastrosComponent } from './componentes/estudante/listar-cadastros/listar-cadastros.component';
import { DetalheCadastroComponent } from './componentes/estudante/detalhe-cadastro/detalhe-cadastro.component';
import { InserirCursoComponent } from './componentes/curso/inserir-curso/inserir-curso.component';
import { AtualizarCursoComponent } from './componentes/curso/atualizar-curso/atualizar-curso.component';
import { ListarCursoComponent } from './componentes/curso/listar-curso/listar-curso.component';
import { DetalherCursoComponent } from './componentes/curso/detalher-curso/detalher-curso.component';
import { ListarJoinComponent } from './componentes/join/listar-join/listar-join.component';
import { ListarJoinEstudanteComponent } from './componentes/join/listar-join-estudante/listar-join-estudante.component';

const routes: Routes = [
  // definir as rotas
  //http://localhost:4200/listar
  {path: '', redirectTo: 'listar', pathMatch: 'full'},
  {path: 'inserir', component: InserirCadastroComponent},
  {path: 'atualizar/:id', component: AtualizarCadastroComponent},
  {path: 'listar', component: ListarCadastrosComponent},
  {path: 'detalhe/:id', component: DetalheCadastroComponent},
  {path: 'inserirCurso', component: InserirCursoComponent},
  {path: 'atualizarCurso/:id', component: AtualizarCursoComponent},
  {path: 'listarCurso', component: ListarCursoComponent},
  {path: 'detalheCurso/:id', component: DetalherCursoComponent},
  {path: 'listarJoin', component: ListarJoinComponent},
  {path: 'listarJoinEstudante', component: ListarJoinEstudanteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
