import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SessionConnectComponent } from './session-connect.component';

describe('SessionConnectComponent', () => {
  let component: SessionConnectComponent;
  let fixture: ComponentFixture<SessionConnectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SessionConnectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SessionConnectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
