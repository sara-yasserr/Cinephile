/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ShowtimeApiService } from './ShowtimeApi.service';

describe('Service: ShowtimeApi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ShowtimeApiService]
    });
  });

  it('should ...', inject([ShowtimeApiService], (service: ShowtimeApiService) => {
    expect(service).toBeTruthy();
  }));
});
