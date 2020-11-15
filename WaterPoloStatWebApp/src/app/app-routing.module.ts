import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ModificaStatisticheComponent } from './modifica-statistiche/modifica-statistiche.component';

const routes: Routes = [
  { path:"editstat", component: ModificaStatisticheComponent},
  { path:"**", component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
