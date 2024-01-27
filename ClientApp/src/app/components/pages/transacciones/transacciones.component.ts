import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { DetalleTransacciones } from '../../../interfaces/detalle-transaccion';
import { Comercio } from '../../../interfaces/comercio';
import { Transacciones } from '../../../interfaces/transaccion';
import { ComercioService } from '../../../services/comercio.service';
import { TransaccionesService } from '../../../services/transaccion.service';
import { MatDialog } from '@angular/material/dialog';
import { DialogResultadoTransaccionesComponent } from '../modals/dialog-resultado-transaccion/dialog-resultado-transaccion.component';
import { MatSnackBar } from '@angular/material/snack-bar';



@Component({
  selector: 'app-transaccion',
  templateUrl: './transaccion.component.html',
  styleUrls: ['./transaccion.component.css']
})
export class TransaccionesComponent implements OnInit {
  options: Comercio[] = [];
  ELEMENT_DATA: DetalleTransacciones[] = [];
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
    private _transaccionServicio: TransaccionesService,
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

    const _cantidad: number = this.formGroup.value.cantidad;
    const _precio: number = parseFloat(this.agregarComercio.precio);
    const _total: number = _cantidad * _precio;
    this.totalPagar = this.totalPagar + _total;

    this.ELEMENT_DATA.push(
      {
        idComercio: this.agregarComercio.idComercio,
        descripcionComercio: this.agregarComercio.nombre,
        color: this.agregarComercio.color,
        cantidad: _cantidad,
        precioTexto: String(_precio.toFixed(2)),
        totalTexto: String(_total.toFixed(2))
      })
    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);

    this.formGroup.patchValue({
      comercio: '',
      cantidad: ''
    })

  }

  eliminarComercio(item: DetalleTransacciones) {

    this.totalPagar = this.totalPagar - parseFloat(item.totalTexto);
    this.ELEMENT_DATA = this.ELEMENT_DATA.filter(p => p.idComercio != item.idComercio)

    this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);
  }

  registrarTransacciones() {

    if (this.ELEMENT_DATA.length > 0) {

      this.deshabilitado = true;
      

      const transaccionDto: Transacciones = {
        tipoPago: this.tipodePago,
        totalTexto: String(this.totalPagar.toFixed(2)),
        detalleTransacciones: this.ELEMENT_DATA
      }

      this._transaccionServicio.registrar(transaccionDto).subscribe({
        next: (data) => {

          if (data.status) {
            this.totalPagar = 0.00;
            this.ELEMENT_DATA = [];
            this.dataSource = new MatTableDataSource(this.ELEMENT_DATA);
            this.tipodePago = "Efectivo";

            this.dialog.open(DialogResultadoTransaccionesComponent, {
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
