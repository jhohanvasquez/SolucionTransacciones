import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { NavigationComponent } from './navigation/navigation.component';
import { PagesComponent } from './pages.component';

import { ReusableModule } from '../reusable/reusable.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { DialogUsuarioComponent } from './modals/dialog-usuario/dialog-usuario.component';
import { DialogComercioComponent } from './modals/dialog-comercio/dialog-comercio.component';
import { DialogDeleteUsuarioComponent } from './modals/dialog-delete-usuario/dialog-delete-usuario.component';
import { ComerciosComponent } from './comercios/comercios.component';
import { TransaccionesComponent } from './transacciones/transacciones.component';
import { DialogDeleteComercioComponent } from './modals/dialog-delete-comercio/dialog-delete-comercio.component';
import { DialogResultadoTransaccionComponent } from './modals/dialog-resultado-transaccion/dialog-resultado-transaccion.component';
import { ReportesComponent } from './reportes/reportes.component';




@NgModule({
  declarations: [
    PagesComponent,
    NavigationComponent,
    DashboardComponent,
    UsuariosComponent,
    ComerciosComponent,
    ReportesComponent,
    TransaccionesComponent,
    DialogUsuarioComponent,
    DialogComercioComponent,
    DialogDeleteUsuarioComponent,
    DialogDeleteComercioComponent,
    DialogResultadoTransaccionComponent,
  ],
  imports: [
    CommonModule,
    PagesRoutingModule,

    ReusableModule
  ]
})
export class PagesModule { }
