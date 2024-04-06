import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalherCursoComponent } from './detalher-curso.component';

describe('DetalherCursoComponent', () => {
  let component: DetalherCursoComponent;
  let fixture: ComponentFixture<DetalherCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetalherCursoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetalherCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
