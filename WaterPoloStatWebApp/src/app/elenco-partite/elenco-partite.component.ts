import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ElencoPartita } from '../shared/models/elencoPartita';
import { PartitaService } from '../shared/services/partitaService';

@Component({
  selector: 'app-elenco-partite',
  templateUrl: './elenco-partite.component.html'
})
export class ElencoPartiteComponent implements OnInit {
  ricerca = 'Ricerca';
  public ElencoPartite!: ElencoPartita[];
  constructor(private partitaService: PartitaService, private router: Router) { }

  ngOnInit(): void {
    this.partitaService.getPartite().subscribe({
      next: (result) => {
          this.ElencoPartite = result;
      }});
  }

  goToPage(url:string){    
    this.router.navigateByUrl(url);
  }

}
