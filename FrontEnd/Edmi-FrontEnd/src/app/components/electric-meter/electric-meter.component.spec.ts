import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElectricMeterComponent } from './electric-meter.component';

describe('ElectricMeterComponent', () => {
  let component: ElectricMeterComponent;
  let fixture: ComponentFixture<ElectricMeterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ElectricMeterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ElectricMeterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
