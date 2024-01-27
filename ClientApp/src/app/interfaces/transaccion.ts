import { DetalleTransaccion } from "./detalle-transaccion";

export interface Transaccion {
  idTransaccion?: number,
  numeroDocumento?: string,
  color?: string,
  fechaRegistro?: string,
  tipoPago?: string,
  totalTexto?: string,
  detalleTransaccion?:DetalleTransaccion[]
}
