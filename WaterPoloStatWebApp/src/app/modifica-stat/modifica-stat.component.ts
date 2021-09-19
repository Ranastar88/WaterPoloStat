import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddGoalComponent } from '../shared/components/add-goal/add-goal.component';

@Component({
  selector: 'app-modifica-stat',
  templateUrl: './modifica-stat.component.html'
})
export class ModificaStatComponent implements OnInit {

  
  constructor(public dialog: MatDialog) {}

  aggiungiGoal(): void {
    const dialogRef = this.dialog.open(AddGoalComponent, {
      
    });

    dialogRef.afterClosed().subscribe(result => {
      
    });
  }

  ngOnInit(): void {
  }

}
