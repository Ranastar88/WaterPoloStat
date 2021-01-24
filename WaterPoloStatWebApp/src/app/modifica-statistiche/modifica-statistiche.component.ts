import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddGoalComponent } from '../shared/component/add-goal/add-goal.component';

@Component({
  selector: 'app-modifica-statistiche',
  templateUrl: './modifica-statistiche.component.html'
})
export class ModificaStatisticheComponent implements OnInit {
public elenco:number[];
  constructor(public dialog: MatDialog) { 
    this.elenco = Array(14).fill(14).map((x,i)=>i+1);
  }

  ngOnInit(): void {
  }
  addGoal() {
    const dialogRef = this.dialog.open(AddGoalComponent);

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
