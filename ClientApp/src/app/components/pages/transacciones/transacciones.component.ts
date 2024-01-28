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
import { MedioPagoService } from '../../../services/medio-pago-servicio.service';
import { MedioPago } from '../../../interfaces/medio-pago';



@Component({
  selector: 'app-transacciones',
  templateUrl: './transacciones.component.html',
  styleUrls: ['./transacciones.component.css']
})
export class TransaccionesComponent implements OnInit {
  options: Comercio[] = [];
  ELEMENT_DATA: Transaccion[] = [];
  deshabilitado: boolean = false;

  filteredOptions!: Comercio[];
  agregarTransaccion!: Transaccion;
  tipodePago: string = "Efectivo";
  totalPagar: number = 0;
  listaMedioPago: MedioPago[] = [];

  formGroup: FormGroup;
  displayedColumns: string[] = ['comercio', 'medio_pago', 'concepto', 'estado', 'total','accion'];
  dataSource = new MatTableDataSource(this.ELEMENT_DATA);

  constructor(
    private fb: FormBuilder,
    private _comercioServicio: ComercioService,
    private _transaccionServicio: TransaccionService,
    private dialog: MatDialog,
    private _snackBar: MatSnackBar,
    private _medioPagoServicio: MedioPagoService,
  ) {

    this.formGroup = this.fb.group({
      codigo: [0, Validators.required],
      comercio: ['', Validators.required],
      medio_pago: ['', Validators.required],
      concepto: ['', Validators.required],
      total: [0, Validators.required]
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

    this._medioPagoServicio.getMedioPagos().subscribe({
      next: (data) => {

        if (data.status) {

          this.listaMedioPago = data.value;          

        }
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
    this.agregarTransaccion = event.option.value;
  }

  onSubmitForm() {

    this.totalPagar = this.totalPagar;

    this.ELEMENT_DATA.push(
      {
        codigo: this.agregarTransaccion.codigo,
        codigoComercio: this.agregarTransaccion.codigoComercio,
        medio_pago: this.agregarTransaccion.medio_pago,
        concepto: this.agregarTransaccion.concepto,
        total: Number(this.agregarTransaccion.total.toFixed(2))
      })
    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

    this.formGroup.patchValue({
      codigo: '',
      comercio: '',
      concepto: '',
      medio_pago: '',
      total: ''
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
        codigo: this.agregarTransaccion.codigo,
        codigoComercio: this.agregarTransaccion.codigoComercio,
        medio_pago: this.agregarTransaccion.medio_pago,
        concepto: this.agregarTransaccion.concepto,
        total: Number(this.agregarTransaccion.total.toFixed(2))
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
