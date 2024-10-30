import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistenciasComponent } from './existencias.component';

describe('SoporteComponent', () => {
  let component: ExistenciasComponent;
  let fixture: ComponentFixture<ExistenciasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExistenciasComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExistenciasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
