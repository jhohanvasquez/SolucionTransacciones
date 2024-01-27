import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DepartamentoTransaccion } from '../../../../interfaces/departamentoventa';
import { Comercio } from '../../../../interfaces/comercio';
import { DepartamentoTransaccionService } from '../../../../services/departamentoventa.service';
import { ComercioService } from '../../../../services/comercio.service';

@Component({
  selector: 'app-dialog-comercio',
  templateUrl: './dialog-comercio.component.html',
  styleUrls: ['./dialog-comercio.component.css']
})
export class DialogComercioComponent implements OnInit {
  formComercio: FormGroup;
  accion: string = "Agregar"
  accionBoton: string = "Guardar";
  listaDepartamentoTransaccions: DepartamentoTransaccion[] = [];




  constructor(
    private dialogoReferencia: MatDialogRef<DialogComercioComponent>,
    @Inject(MAT_DIALOG_DATA) public comercioEditar: Comercio,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _DepartamentoTransaccionServicio: DepartamentoTransaccionService,
    private _comercioServicio: ComercioService
  ) {
    this.formComercio = this.fb.group({
      nombre: ['', Validators.required],
      idDepartamentoTransaccion: ['', Validators.required],
      stock: ['', Validators.required],
      precio: ['', Validators.required],
    })


    if (this.comercioEditar) {

      this.accion = "Editar";
      this.accionBoton = "Actualizar";
    }

    this._DepartamentoTransaccionServicio.getDepartamentoTransaccions().subscribe({
      next: (data) => {

        if (data.status) {

          this.listaDepartamentoTransaccions = data.value;

          if (this.comercioEditar)
            this.formComercio.patchValue({
              idDepartamentoTransaccion: this.comercioEditar.idDepartamentoTransaccion
            })

        }
      },
      error: (e) => {
      },
      complete: () => {
      }
    })

  }


  ngOnInit(): void {

    if (this.comercioEditar) {
      console.log(this.comercioEditar)
      this.formComercio.patchValue({
        nombre: this.comercioEditar.nombre,
        idDepartamentoTransaccion: String(this.comercioEditar.idDepartamentoTransaccion),
        stock: this.comercioEditar.stock,
        precio:this.comercioEditar.precio
      })
    }
  }

  agregarEditarComercio() {

    const _comercio: Comercio = {
      idComercio: this.comercioEditar == null ? 0 : this.comercioEditar.idComercio,
      nombre: this.formComercio.value.nombre,
      color: this.formComercio.value.color,
      idDepartamentoTransaccion: this.formComercio.value.idDepartamentoTransaccion,
      descripcionDepartamentoTransaccion : "",
      precio: this.formComercio.value.precio,
      stock: this.formComercio.value.stock
    }



    if (this.comercioEditar) {

      this._comercioServicio.edit(_comercio).subscribe({
        next: (data) => {

          if (data.status) {
            this.mostrarAlerta("El comercio fue editado", "Exito");
            this.dialogoReferencia.close('editado')
          } else {
            this.mostrarAlerta("No se pudo editar el comercio", "Error");
          }

        },
        error: (e) => {
          console.log(e)
        },
        complete: () => {
        }
      })


    } else {

      this._comercioServicio.save(_comercio).subscribe({
        next: (data) => {

          if (data.status) {
            this.mostrarAlerta("El comercio fue registrado", "Exito");
            this.dialogoReferencia.close('agregado')
          } else {
            this.mostrarAlerta("No se pudo registrar el comercio", "Error");
          }

        },
        error: (e) => {
        },
        complete: () => {
        }
      })


    }
  }

  mostrarAlerta(mensaje: string, tipo: string) {
    this._snackBar.open(mensaje, tipo, {
      horizontalPosition: "end",
      verticalPosition: "top",
      duration: 3000
    });
  }

}
