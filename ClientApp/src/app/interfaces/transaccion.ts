import { DetalleTransaccion } from "./detalle-transaccion";

export interface Transaccion {
  codigo: number,
  medio_pago?: number,
  estado?: number,
  total: number,
  fecha?: string,
  concepto?: string,
  identificacionUsuario?: string,
  codigoComercio?: number
}
