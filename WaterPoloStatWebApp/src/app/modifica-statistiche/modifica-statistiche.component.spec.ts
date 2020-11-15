import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificaStatisticheComponent } from './modifica-statistiche.component';

describe('ModificaStatisticheComponent', () => {
  let component: ModificaStatisticheComponent;
  let fixture: ComponentFixture<ModificaStatisticheComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModificaStatisticheComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModificaStatisticheComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
