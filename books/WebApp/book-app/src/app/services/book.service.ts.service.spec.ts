import { TestBed } from '@angular/core/testing';

import { Book.Service.TsService } from './book.service';

describe('Book.Service.TsService', () => {
  let service: Book.Service.TsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Book.Service.TsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
