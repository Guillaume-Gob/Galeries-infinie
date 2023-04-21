/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GaleriesInfinieServiceService } from './GaleriesInfinieService.service';

describe('Service: GaleriesInfinieService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GaleriesInfinieServiceService]
    });
  });

  it('should ...', inject([GaleriesInfinieServiceService], (service: GaleriesInfinieServiceService) => {
    expect(service).toBeTruthy();
  }));
});
