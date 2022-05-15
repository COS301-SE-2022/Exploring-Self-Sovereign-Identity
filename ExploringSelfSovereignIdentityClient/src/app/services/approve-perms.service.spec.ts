import { TestBed } from '@angular/core/testing';

import { ApprovePermsService } from './approve-perms.service';

describe('ApprovePermsService', () => {
  let service: ApprovePermsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApprovePermsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
