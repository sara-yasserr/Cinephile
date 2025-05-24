/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { MovieApiService } from './MovieApi.service';

describe('Service: MovieApi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MovieApiService]
    });
  });

  it('should ...', inject([MovieApiService], (service: MovieApiService) => {
    expect(service).toBeTruthy();
  }));
});
