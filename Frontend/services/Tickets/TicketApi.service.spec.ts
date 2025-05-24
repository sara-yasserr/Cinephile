/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TicketApiService } from './TicketApi.service';

describe('Service: TicketApi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TicketApiService]
    });
  });

  it('should ...', inject([TicketApiService], (service: TicketApiService) => {
    expect(service).toBeTruthy();
  }));
});
