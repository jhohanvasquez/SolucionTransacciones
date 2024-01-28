import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DetalleTransaccion } from '../../../../interfaces/detalle-transaccion';
import { Transaccion } from '../../../../interfaces/transaccion';
@Component({
  selector: 'app-dialog-detalle-transaccion',
  templateUrl: './dialog-detalle-transaccion.component.html',
  styleUrls: ['./dialog-detalle-transaccion.component.css']
})
export class DialogDetalleTransaccionComponent implements OnInit {


  fecha?: string = "";
  codigo?: number = 0;
  concepto?: string = "";
  total?: number = 0;
  displayedColumns: string[] = ['comercio', 'concepto','total'];
 

  constructor(@Inject(MAT_DIALOG_DATA) public _transaccion: Transaccion) {
    this.fecha = _transaccion.fecha;
    this.codigo = _transaccion.codigo;
    this.concepto = _transaccion.concepto;
    this.total = _transaccion.total;    
  }

  ngOnInit(): void {
    
  }

}
