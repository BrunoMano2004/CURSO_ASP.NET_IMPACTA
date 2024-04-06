import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegUnicoJoinEstudanteComponent } from './reg-unico-join-estudante.component';

describe('RegUnicoJoinEstudanteComponent', () => {
  let component: RegUnicoJoinEstudanteComponent;
  let fixture: ComponentFixture<RegUnicoJoinEstudanteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegUnicoJoinEstudanteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegUnicoJoinEstudanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
