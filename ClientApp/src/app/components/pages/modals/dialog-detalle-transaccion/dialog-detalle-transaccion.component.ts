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
    { codigoComercio: 1, descripcionComercio: "", nit: "", direccion: "0", totalTexto: "0" },
  ]
  displayedColumns: string[] = ['comercio', 'nit', 'direccion','total'];
 

  constructor(@Inject(MAT_DIALOG_DATA) public _venta: Transaccion) {
    this.fechaRegistro = _venta.fechaRegistro;
    this.numero = _venta.numeroDocumento;
    this.tipoPago = _venta.tipoPago;
    this.total = _venta.totalTexto;
    this.detalleTransaccion = _venta.detalleTransaccion == null ? [
      { codigoComercio: 1, descripcionComercio: "", nit: "", direccion: "0", totalTexto: "0" },
    ] : _venta.detalleTransaccion;
  }

  ngOnInit(): void {
    
  }

}
