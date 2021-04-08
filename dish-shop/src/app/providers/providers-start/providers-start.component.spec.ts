import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProvidersStartComponent } from './providers-start.component';

describe('ProvidersStartComponent', () => {
  let component: ProvidersStartComponent;
  let fixture: ComponentFixture<ProvidersStartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProvidersStartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProvidersStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
