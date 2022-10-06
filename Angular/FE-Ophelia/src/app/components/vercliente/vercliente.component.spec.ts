import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerclienteComponent } from './vercliente.component';

describe('VerclienteComponent', () => {
  let component: VerclienteComponent;
  let fixture: ComponentFixture<VerclienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerclienteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(VerclienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
