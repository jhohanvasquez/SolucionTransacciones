import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Comercio } from '../../../interfaces/comercio';
import { ComercioService } from '../../../services/comercio.service';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TransaccionService } from '../../../services/transaccion.service';
import { DetalleTransaccion } from '../../../interfaces/detalle-transaccion';
import { Transaccion } from '../../../interfaces/transaccion';
import { DialogResultadoTransaccionComponent } from '../modals/dialog-resultado-transaccion/dialog-resultado-transaccion.component';



@Component({
  selector: 'app-transacciones',
  templateUrl: './transacciones.component.html',
  styleUrls: ['./transacciones.component.css']
})
export class TransaccionesComponent implements OnInit {
  options: Comercio[] = [];
  ELEMENT_DATA: DetalleTransaccion[] = [];
  deshabilitado: boolean = false;

  filteredOptions!: Comercio[];
  agregarComercio!: Comercio;
  tipodePago: string = "Efectivo";
  totalPagar: number = 0;

  formGroup: FormGroup;
  displayedColumns: string[] = ['comercio', 'color', 'cantidad', 'precio', 'total','accion'];
  dataSource = new MatTableDataSource(this.ELEMENT_DATA);

  constructor(
    private fb: FormBuilder,
    private _comercioServicio: ComercioService,
    private _transaccionServicio: TransaccionService,
    private dialog: MatDialog,
    private _snackBar: MatSnackBar,
  ) {

    this.formGroup = this.fb.group({
      comercio: ['', Validators.required],
      cantidad: ['', Validators.required]
    })

    this.formGroup.get('comercio')?.valueChanges.subscribe(value => {
      this.filteredOptions =  this._filter(value)
    })

    this._comercioServicio.getComercios().subscribe({
      next: (data) => {
        if (data.status)
          this.options = data.value;
      },
      error: (e) => {
      },
      complete: () => {

      }
    })

  }

  ngOnInit(): void {

  }

  private _filter(value: any): Comercio[] {
    const filterValue = typeof value === "string" ? value.toLowerCase() : value.nombre.toLowerCase();
    return this.options.filter(option => option.nombre.toLowerCase().includes(filterValue));
  }


  displayComercio(comercio: Comercio): string {
    return comercio.nombre;
  }

  comercioSeleccionado(event: any) {
    this.agregarComercio = event.option.value;
  }

  onSubmitForm() {

    this.totalPagar = this.totalPagar;

    this.ELEMENT_DATA.push(
      {
        codigoComercio: this.agregarComercio.codigo,
        descripcionComercio: this.agregarComercio.nombre,
        nit: this.agregarComercio.nit,
        direccion: this.agregarComercio.direccion,
        totalTexto: String(this.totalPagar.toFixed(2))
      })
    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

    this.formGroup.patchValue({
      comercio: '',
      cantidad: ''
    })

  }

  eliminarComercio(item: DetalleTransaccion) {

    this.totalPagar = this.totalPagar - parseFloat(item.totalTexto);
    this.ELEMENT_DATA = this.ELEMENT_DATA.filter(p => p.codigoComercio != item.codigoComercio)

    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);
  }

  registrarTransaccion() {

    if (this.ELEMENT_DATA.length > 0) {

      this.deshabilitado = true;
      

      const transaccionDto: Transaccion = {
        tipoPago: this.tipodePago,
        totalTexto: String(this.totalPagar.toFixed(2))
      }

      this._transaccionServicio.registrar(transaccionDto).subscribe({
        next: (data) => {

          if (data.status) {
            this.totalPagar = 0.00;
            this.ELEMENT_DATA = [];
            this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);
            this.tipodePago = "Efectivo";

            this.dialog.open(DialogResultadoTransaccionComponent, {
              data: {
                numero: data.value.numeroDocumento
              },
            });

          } else {
            this._snackBar.open("No se pudo registrar la transaccion", "Oops", {
              horizontalPosition: "end",
              verticalPosition: "top",
              duration: 3000
            });
          }
        },
        error: (e) => {
        },
        complete: () => {
          this.deshabilitado = false;
        }
      })


    }
  }


}
