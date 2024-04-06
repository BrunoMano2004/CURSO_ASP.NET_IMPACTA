import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
// importar o FormsModule 
import { FormsModule } from '@angular/forms';
// importar o módulo de recursos de requisição http
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
// importar o service
import { EstudanteApiService } from './service/estudante-api.service';
import { JoinApiService } from './service/join-api.service';
import { CursoApiService } from './service/curso-api.service';
import { JoinApiEstudanteService} from './service/join-api-estudante.service';
// componentes
import { InserirCadastroComponent } from './componentes/estudante/inserir-cadastro/inserir-cadastro.component';
import { AtualizarCadastroComponent } from './componentes/estudante/atualizar-cadastro/atualizar-cadastro.component';
import { ListarCadastrosComponent } from './componentes/estudante/listar-cadastros/listar-cadastros.component';
import { DetalheCadastroComponent } from './componentes/estudante/detalhe-cadastro/detalhe-cadastro.component';
import { ListarCursoComponent } from './componentes/curso/listar-curso/listar-curso.component';
import { AtualizarCursoComponent } from './componentes/curso/atualizar-curso/atualizar-curso.component';
import { InserirCursoComponent } from './componentes/curso/inserir-curso/inserir-curso.component';
import { DetalherCursoComponent } from './componentes/curso/detalher-curso/detalher-curso.component';
import { ListarJoinComponent } from './componentes/join/listar-join/listar-join.component';
import { ListarJoinEstudanteComponent } from './componentes/join/listar-join-estudante/listar-join-estudante.component';
import { RegUnicoJoinEstudanteComponent } from './componentes/join/reg-unico-join-estudante/reg-unico-join-estudante.component';
import { RegUnicoJoinComponent } from './componentes/join/reg-unico-join/reg-unico-join.component';

@NgModule({
  declarations: [
    AppComponent,
    InserirCadastroComponent,
    AtualizarCadastroComponent,
    ListarCadastrosComponent,
    DetalheCadastroComponent,
    ListarCursoComponent,
    AtualizarCursoComponent,
    InserirCursoComponent,
    DetalherCursoComponent,
    ListarJoinComponent,
    ListarJoinEstudanteComponent,
    RegUnicoJoinEstudanteComponent,
    RegUnicoJoinComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [EstudanteApiService, CursoApiService, JoinApiService, JoinApiEstudanteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
