import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PagesComponent } from './pages.component';
import { ComerciosComponent } from './comercios/comercios.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { TransaccionesComponent } from './transacciones/transacciones.component';

const routes: Routes = [
  {
    path: '', component: PagesComponent, children: [
      {path:'dashboard',component:DashboardComponent},
      { path: 'usuarios', component: UsuariosComponent },
       {path:'comercios',component:ComerciosComponent},
      {path:'transacciones',component:TransaccionesComponent}
    ]
  }
  ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PagesRoutingModule { }
