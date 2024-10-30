import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SalidaComponent } from './salida.component';

describe('EntradaComponent', () => {
  let component: SalidaComponent;
  let fixture: ComponentFixture<SalidaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SalidaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SalidaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
