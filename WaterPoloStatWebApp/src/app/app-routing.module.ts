import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ModificaPartitaComponent } from './modifica-partita/modifica-partita.component';
import { ModificaStatisticheComponent } from './modifica-statistiche/modifica-statistiche.component';
import { RegistrazioneComponent } from './registrazione/registrazione.component';

const routes: Routes = [
  { path:"editmatch", component: ModificaPartitaComponent},
  { path:"editstat", component: ModificaStatisticheComponent},
  { path:"login", component: LoginComponent},
  { path:"registrazione", component: RegistrazioneComponent},
  { path:"**", component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
