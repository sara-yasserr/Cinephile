/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BookingApiService } from './BookingApi.service';

describe('Service: BookingApi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookingApiService]
    });
  });

  it('should ...', inject([BookingApiService], (service: BookingApiService) => {
    expect(service).toBeTruthy();
  }));
});
