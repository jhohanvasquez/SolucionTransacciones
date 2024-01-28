using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class ZonaVirtual
    {
        public int comercio_codigo { get; set; }
        public string? comercio_nombre { get; set; }
        public string? comercio_nit { get; set; }
        public string? comercio_direccion { get; set; }
        public int Trans_codigo { get; set; }
        public int Trans_medio_pago { get; set; }
        public int Trans_estado { get; set; }
        public double Trans_total { get; set; }
        public string? Trans_fecha { get; set; }
        public string? Trans_concepto { get; set; }
        public string? usuario_identificacion { get; set; }
        public string? usuario_nombre { get; set; }
        public string? usuario_email { get; set; }
    }
}
