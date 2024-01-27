import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Comercio } from '../../../../interfaces/comercio';

@Component({
  selector: 'app-dialog-delete-comercio',
  templateUrl: './dialog-delete-comercio.component.html',
  styleUrls: ['./dialog-delete-comercio.component.css']
})
export class DialogDeleteComercioComponent implements OnInit {

  constructor(
    private dialogoReferencia: MatDialogRef<DialogDeleteComercioComponent>,
    @Inject(MAT_DIALOG_DATA) public comercioEliminar: Comercio
  ) { }

  ngOnInit(): void {
  }


  eliminarComercio() {
    if (this.comercioEliminar) {
      this.dialogoReferencia.close('eliminar')
    }
  }

}
