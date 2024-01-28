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
import { CookieService } from 'ngx-cookie-service';



@Component({
  selector: 'app-transacciones',
  templateUrl: './transacciones.component.html',
  styleUrls: ['./transacciones.component.css'],
  providers: [CookieService]
})
export class TransaccionesComponent implements OnInit {
  options: Comercio[] = [];
  ELEMENT_DATA: Transaccion[] = [];
  deshabilitado: boolean = false;

  filteredOptions!: Comercio[];
  agregarComercio!: Comercio;
  agregarMedioPago!: MedioPago;
  tipodePago: string = "Efectivo";
  totalPagar: number = 0;
  listaMedioPago: MedioPago[] = [];
  nombreComercio: string = '';

  formGroup: FormGroup;
  displayedColumns: string[] = ['comercio', 'medio_pago', 'concepto', 'total', 'accion'];
  dataSource = new MatTableDataSource(this.ELEMENT_DATA);

  constructor(
    private cookieService: CookieService,
    private fb: FormBuilder,
    private _comercioServicio: ComercioService,
    private _transaccionServicio: TransaccionService,
    private dialog: MatDialog,
    private _snackBar: MatSnackBar,
    private _medioPagoServicio: MedioPagoService,
  ) {

    this.formGroup = this.fb.group({
      codigo: ['', Validators.required],
      comercio: ['', Validators.required],
      medio_pago: ['', Validators.required],
      concepto: ['', Validators.required],
      total: ['', Validators.required]
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
        debugger;
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
    this.agregarComercio = event.option.value;
  }

  medioPagoSeleccionado(event: any) {
    debugger;
    let target = event.source.selected._element.nativeElement;
    this.agregarMedioPago = {
      idMedio: event.value,
      descripcion: target.innerText.trim()
    };
  }

  onSubmitForm() {

    this.ELEMENT_DATA.push(
      {
        codigo: this.formGroup.value.codigo,
        codigoComercio: this.agregarComercio.codigo,
        nombreComercio: this.agregarComercio.nombre,
        medio_pago: this.agregarMedioPago.idMedio,
        nombreMediopago: this.agregarMedioPago.descripcion,
        concepto: this.formGroup.value.concepto,
        total: this.formGroup.value.total
      })

    debugger;

    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

    this.formGroup.patchValue({
      codigo: '',
      comercio: '',
      codigoComercio: '',
      nombreComercio: '',      
      medio_pago: '',
      concepto: '',
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

      this.ELEMENT_DATA.forEach( (item) => {

        const transaccionDto: Transaccion = {
          codigo: item.codigo,
          codigoComercio: item.codigoComercio,
          nombreComercio: '',
          medio_pago: item.medio_pago,
          concepto: item.concepto,
          total: item.total,
          identificacionUsuario: this.cookieService.get('identificacion'),
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
              this._snackBar.open("No se pudo registrar la transaccion codigo" + item.codigo, "Oops", {
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
       
      }); 

    }
  }


}
