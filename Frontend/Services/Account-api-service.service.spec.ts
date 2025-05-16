/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AccountApiServiceService } from './Account-api-service.service';

describe('Service: AccountApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccountApiServiceService]
    });
  });

  it('should ...', inject([AccountApiServiceService], (service: AccountApiServiceService) => {
    expect(service).toBeTruthy();
  }));
});
