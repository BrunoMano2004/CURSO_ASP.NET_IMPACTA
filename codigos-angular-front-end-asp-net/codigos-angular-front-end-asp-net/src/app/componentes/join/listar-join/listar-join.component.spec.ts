import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarJoinComponent } from './listar-join.component';

describe('ListarJoinComponent', () => {
  let component: ListarJoinComponent;
  let fixture: ComponentFixture<ListarJoinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListarJoinComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListarJoinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
