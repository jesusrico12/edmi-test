import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GatewayMeterComponent } from './gateway-meter.component';

describe('GatewayMeterComponent', () => {
  let component: GatewayMeterComponent;
  let fixture: ComponentFixture<GatewayMeterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GatewayMeterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GatewayMeterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
