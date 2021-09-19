import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ElencoPartiteComponent } from './elenco-partite/elenco-partite.component';
import { LoginComponent } from './login/login.component';
import { ModificaPartitaComponent } from './modifica-partita/modifica-partita.component';
import { ModificaStatComponent } from './modifica-stat/modifica-stat.component';
import { RegistrazioneComponent } from './registrazione/registrazione.component';
import { AuthGuard } from './shared/helpers/authGuard';

const routes: Routes = [  
  { path: 'elencopartite', component: ElencoPartiteComponent, canActivate: [AuthGuard] },
  { path: 'nuovapartita', component: ModificaPartitaComponent, canActivate: [AuthGuard] },
  { path: 'modificapartita/:id', component: ModificaPartitaComponent, canActivate: [AuthGuard] },
  { path: 'modificastat/:id', component: ModificaStatComponent, canActivate: [AuthGuard] },
  { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'registrati', component: RegistrazioneComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
