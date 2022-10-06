import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VercompraComponent } from './vercompra.component';

describe('VercompraComponent', () => {
  let component: VercompraComponent;
  let fixture: ComponentFixture<VercompraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VercompraComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VercompraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
