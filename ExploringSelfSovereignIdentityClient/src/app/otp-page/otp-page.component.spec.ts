import { ComponentFixture, TestBed } from '@angular/core/testing';
import { async } from 'rxjs';

import { OtpPageComponent } from './otp-page.component';

describe('OtpPageComponent', () => {
  let component: OtpPageComponent;
  let fixture: ComponentFixture<OtpPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OtpPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(async() => {
    fixture = TestBed.createComponent(OtpPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

//  it('should create', () => {
//    expect(component).toBeTruthy();
//  });
});
