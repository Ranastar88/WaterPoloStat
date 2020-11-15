import { Component, HostListener } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'WaterPoloStatWebApp';

constructor(
  private titlePage: Title,
  private meta: Meta){}
}
