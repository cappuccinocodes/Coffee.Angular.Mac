import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CoffeeFormComponent } from './coffee-form.component';

describe('CoffeeFormComponent', () => {
  let component: CoffeeFormComponent;
  let fixture: ComponentFixture<CoffeeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CoffeeFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CoffeeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
