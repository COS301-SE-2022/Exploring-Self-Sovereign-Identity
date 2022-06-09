import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AcceptPermissionsComponent } from './accept-permissions.component';

describe('AcceptPermissionsComponent', () => {
  let component: AcceptPermissionsComponent;
  let fixture: ComponentFixture<AcceptPermissionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AcceptPermissionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AcceptPermissionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
