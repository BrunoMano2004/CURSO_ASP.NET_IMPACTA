import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarJoinEstudanteComponent } from './listar-join-estudante.component';

describe('ListarJoinEstudanteComponent', () => {
  let component: ListarJoinEstudanteComponent;
  let fixture: ComponentFixture<ListarJoinEstudanteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarJoinEstudanteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarJoinEstudanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
