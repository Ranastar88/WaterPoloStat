import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }
  nuovaPartita():void{
    this.router.navigate(['/nuovapartita']);
  }
  elencoPartite():void{
    this.router.navigate(['/elencopartite']);
  }
}
