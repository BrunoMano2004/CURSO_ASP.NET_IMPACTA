import { TestBed } from '@angular/core/testing';

import { JoinApiEstudanteService } from './join-api-estudante.service';

describe('JoinApiEstudanteService', () => {
  let service: JoinApiEstudanteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(JoinApiEstudanteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
