import { Component, OnInit, ViewChild } from '@angular/core';

import { Chart, registerables } from 'node_modules/chart.js';
import { DashboardService } from '../../../services/dashboard.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ComercioService } from '../../../services/comercio.service';
import { TransaccionService } from '../../../services/transaccion.service';
import { CookieService } from 'ngx-cookie-service';

Chart.register(...registerables);

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  totalProductos: string = "0";
  displayedColumns: string[] = ['descripcionComercio', 'codigo', 'fecha', 'concepto', 'identificacionUsuario', 'total', 'accion'];
  dataSource = new MatTableDataSource();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(
    private _dashboardServicio: DashboardService,
    private cookieService: CookieService,
    private dialog: MatDialog,
    private _snackBar: MatSnackBar,
    private _comercioServicio: ComercioService,
    private _transaccionServicio: TransaccionService
  ) {


  }

  ngOnInit(): void {
    this.mostrarReportes();
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  mostrarReportes() {
    debugger;
    this._transaccionServicio.ConsultarTransacciones(this.cookieService.get('identificacion'), this.cookieService.get('idRol')).subscribe({
      next: (data) => {
        debugger;
        if (data.status)
          this.dataSource.data = data.value;
        else
          this._snackBar.open("No se encontraron datos", 'Oops!', { duration: 2000 });
      },
      error: (e) => {
      },
      complete: () => {

      }
    })
  }

  mostrarAlerta(mensaje: string, tipo: string) {
    this._snackBar.open(mensaje, tipo, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    });
  }

}
