import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cronometro',
  templateUrl: './cronometro.component.html'
})
export class CronometroComponent implements OnInit {

  constructor() { }
  public minuti: number = 8;
  public secondi: number = 0;
  public avviato: boolean = false;

  ngOnInit(): void {
    setInterval(() => {
      if (this.avviato) {
        this.decrementaSecondi();
        if (this.secondi == 59) this.decrementaMinuti();
      }
    }, 1000);
  }

  incrementaMinuti(): void {
    this.minuti++;
    if (this.minuti > 8) { this.minuti = 0; return; }
    if (this.minuti < 0) { this.minuti = 8; return; }
    return;
  }

  decrementaMinuti(): void {
    this.minuti--;
    if (this.minuti > 8) { this.minuti = 0; return; }
    if (this.minuti < 0) { this.minuti = 8; return; }
    return;
  }

  incrementaSecondi(): void {
    this.secondi++;
    if (this.secondi > 59) { this.secondi = 0; return; }
    if (this.secondi < 0) { this.secondi = 59; return; }
    return;
  }

  decrementaSecondi(): void {
    this.secondi--;
    if (this.secondi > 59) { this.secondi = 0; return; }
    if (this.secondi < 0) { this.secondi = 59; return; }
    return;
  }

  onChangeMinuti(): void {
    if (this.minuti > 59) { this.minuti = 0; return; }
    if (this.minuti < 0) { this.minuti = 59; return; }
  }

  onChangeSecondi(): void {
    if (this.secondi > 59) { this.secondi = 0; return; }
    if (this.secondi < 0) { this.secondi = 59; return; }
  }

  avviaCronometro(): void {
    this.avviato = true;
  }
  stoppaCronometro():void{this.avviato = false;}
  resetCronometro():void{
    this.avviato = false;
    this.secondi = 0;
    this.minuti = 8;
  }
}
