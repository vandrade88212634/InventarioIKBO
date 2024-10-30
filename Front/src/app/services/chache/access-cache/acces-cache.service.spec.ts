import { TestBed } from '@angular/core/testing';

import { AccesCacheService } from './acces-cache.service';

describe('AccesCacheService', () => {
  let service: AccesCacheService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccesCacheService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
