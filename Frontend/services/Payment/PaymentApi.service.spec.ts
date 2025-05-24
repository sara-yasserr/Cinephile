/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PaymentApiService } from './PaymentApi.service';

describe('Service: PaymentApi', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PaymentApiService]
    });
  });

  it('should ...', inject([PaymentApiService], (service: PaymentApiService) => {
    expect(service).toBeTruthy();
  }));
});
