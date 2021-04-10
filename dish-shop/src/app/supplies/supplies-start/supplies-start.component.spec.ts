import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuppliesStartComponent } from './supplies-start.component';

describe('SuppliesStartComponent', () => {
  let component: SuppliesStartComponent;
  let fixture: ComponentFixture<SuppliesStartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuppliesStartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuppliesStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
