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


  fechaRegistro?: string = "";
  numero?: string = "";
  color?: string = "";
  tipoPago?: string = "";
  total?: string = "";
  detalleTransaccion: DetalleTransaccion[] = [
    { idProducto: 1, descripcionProducto: "", color: "", cantidad:0,precioTexto:"0",totalTexto:"0"},
  ]
  displayedColumns: string[] = ['producto', 'color', 'cantidad', 'precio', 'total'];
 

  constructor(@Inject(MAT_DIALOG_DATA) public _venta: Transaccion) {
    this.fechaRegistro = _venta.fechaRegistro;
    this.numero = _venta.numeroDocumento;
    this.tipoPago = _venta.tipoPago;
    this.total = _venta.totalTexto;
    this.detalleTransaccion = _venta.detalleTransaccion == null ? [
      { idProducto: 1, descripcionProducto: "", color: "", cantidad: 0, precioTexto: "0", totalTexto: "0" },
    ] : _venta.detalleTransaccion;
  }

  ngOnInit(): void {
    
  }

}
