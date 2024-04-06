import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegUnicoJoinComponent } from './reg-unico-join.component';

describe('RegUnicoJoinComponent', () => {
  let component: RegUnicoJoinComponent;
  let fixture: ComponentFixture<RegUnicoJoinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegUnicoJoinComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegUnicoJoinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
