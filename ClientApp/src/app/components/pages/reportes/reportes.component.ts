import { Component, OnInit, ViewChild} from '@angular/core';

import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { DialogComercioComponent } from '../modals/dialog-comercio/dialog-comercio.component';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Comercio } from '../../../interfaces/comercio';
import { DialogDeleteComercioComponent } from '../modals/dialog-delete-comercio/dialog-delete-comercio.component';
import { ComercioService } from '../../../services/comercio.service';
import { TransaccionService } from '../../../services/transaccion.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-reportes',
  templateUrl: './reportes.component.html',
  styleUrls: ['./reportes.component.css']
})
export class ReportesComponent implements OnInit {
  displayedColumns: string[] = ['comercio', 'medio_pago', 'concepto', 'total', 'accion'];
  dataSource = new MatTableDataSource();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
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


  agregarComercio() {
    this.dialog.open(DialogComercioComponent, {
      disableClose: true
    }).afterClosed().subscribe(result => {
      if (result === "agregado") {
        this.mostrarReportes();
      }
    });
  }

  editarComercio(comercio: Comercio) {
    this.dialog.open(DialogComercioComponent, {
      disableClose: true,
      data: comercio
    }).afterClosed().subscribe(result => {

      if (result === "editado")
        this.mostrarReportes();

    });
  }


  eliminarComercio(comercio: Comercio) {
    this.dialog.open(DialogDeleteComercioComponent, {
      disableClose: true,
      data: comercio
    }).afterClosed().subscribe(result => {

      if (result === "eliminar") {

        this._comercioServicio.delete(comercio.codigo).subscribe({
          next: (data) => {

            if (data.status) {
              this.mostrarAlerta("El comercio fue eliminado", "Listo!")
              this.mostrarReportes();
            } else {
              this.mostrarAlerta("No se pudo eliminar el comercio", "Error");
            }

          },
          error: (e) => {
          },
          complete: () => {
          }
        })

      }


    
    });
  }

  mostrarAlerta(mensaje: string, tipo: string) {
    this._snackBar.open(mensaje, tipo, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    });
  }

}
