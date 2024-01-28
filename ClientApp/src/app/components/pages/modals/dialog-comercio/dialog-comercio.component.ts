import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Comercio } from '../../../../interfaces/comercio';
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

  constructor(
    private dialogoReferencia: MatDialogRef<DialogComercioComponent>,
    @Inject(MAT_DIALOG_DATA) public comercioEditar: Comercio,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _comercioServicio: ComercioService
  ) {
    this.formComercio = this.fb.group({
      nombre: ['', Validators.required],
      nit: ['', Validators.required],
      direccion: ['', Validators.required]
    })


    if (this.comercioEditar) {

      this.accion = "Editar";
      this.accionBoton = "Actualizar";
    }

  }


  ngOnInit(): void {

    if (this.comercioEditar) {
      console.log(this.comercioEditar)
      this.formComercio.patchValue({
        nombre: this.comercioEditar.nombre,
        nit: this.comercioEditar.nit,
        direccion: this.comercioEditar.direccion,
      })
    }
  }

  agregarEditarComercio() {

    const _comercio: Comercio = {
      codigo: this.comercioEditar == null ? 0 : this.comercioEditar.codigo,
      nombre: this.formComercio.value.nombre,
      nit: this.formComercio.value.nit,
      direccion: this.formComercio.value.direccion,
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
