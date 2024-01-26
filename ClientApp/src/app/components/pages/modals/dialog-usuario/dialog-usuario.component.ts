import { Component, Inject, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Rol } from '../../../../interfaces/rol';
import { Usuario } from '../../../../interfaces/usuario';
import { RolServicioService } from '../../../../services/rol-servicio.service';
import { UsuarioServicioService } from '../../../../services/usuario-servicio.service';

@Component({
  selector: 'app-dialog-usuario',
  templateUrl: './dialog-usuario.component.html',
  styleUrls: ['./dialog-usuario.component.css']
})
export class DialogUsuarioComponent implements OnInit, AfterViewInit {
  formUsuario: FormGroup;
  hide: boolean = true;
  accion:string ="Agregar"
  accionBoton: string = "Guardar";
  listaRoles: Rol[] = [];

  constructor(
    private dialogoReferencia: MatDialogRef<DialogUsuarioComponent>,
    @Inject(MAT_DIALOG_DATA) public usuarioEditar: Usuario,
    private fb: FormBuilder,
    private _snackBar: MatSnackBar,
    private _rolServicio: RolServicioService,
    private _usuarioServicio: UsuarioServicioService
  )
  {

    this.formUsuario = this.fb.group({
      identificacion: ['', Validators.required],
      nombre: ['', Validators.required],
      email: ['', Validators.required],
      idRol: ['', Validators.required],
      clave: ['', Validators.required],
    })


    if (this.usuarioEditar) {
      this.accion = "Editar";
      this.accionBoton = "Actualizar";
    }

    this._rolServicio.getRoles().subscribe({
      next: (data) => {

        if (data.status) {

          this.listaRoles = data.value;

          if (this.usuarioEditar)
            this.formUsuario.patchValue({
              idRol: this.usuarioEditar.idRol
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
  
    if (this.usuarioEditar) {

      this.formUsuario.patchValue({
        identificacion: this.usuarioEditar.identificacion,
        nombre: this.usuarioEditar.nombre,
        email: this.usuarioEditar.email,
        idRol: this.usuarioEditar.idRol,
        clave: this.usuarioEditar.clave
      })
    }

  }

  ngAfterViewInit() {
    
  }


  agregarEditarUsuario() {

    let identificacionUser = '';

    if (this.usuarioEditar) {
      identificacionUser = this.usuarioEditar == null ? "0" : this.usuarioEditar.identificacion
    }
    else {
      identificacionUser = this.formUsuario.value.identificacion
    }

    const _usuario: Usuario = {
      identificacion: identificacionUser,
      nombre: this.formUsuario.value.nombre,
      email: this.formUsuario.value.email,
      idRol: this.formUsuario.value.idRol,
      rolDescripcion : "",
      clave: this.formUsuario.value.clave
    }


    if (this.usuarioEditar) {

      this._usuarioServicio.editUsuario(_usuario).subscribe({
        next: (data) => {

          if (data.status) {
            this.mostrarAlerta("El usuario fue editado", "Exito");
            this.dialogoReferencia.close('editado')
          } else {
            this.mostrarAlerta("No se pudo editar el usuario", "Error");
          }

        },
        error: (e) => {
          console.log(e)
        },
        complete: () => {
        }
      })

      
    } else {
     
      this._usuarioServicio.saveUsuario(_usuario).subscribe({
        next: (data) => {
          debugger;
          if (data.status) {
            this.mostrarAlerta("El usuario fue registrado", "Exito");
            this.dialogoReferencia.close('agregado')
          } else {
            this.mostrarAlerta("No se pudo registrar el usuario", "Error");
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
