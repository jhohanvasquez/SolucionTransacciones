using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class Transaccion
    {
        public int codigo { get; set; }
        public int? medio_pago { get; set; }
        public int? estado { get; set; }
        public double total { get; set; }
        public string? fecha { get; set; }
        public string? concepto { get; set; }
        public string? identificacionUsuario { get; set; }
        public int? codigoComercio { get; set; }

        public virtual MedioPago? idMedioNavigation { get; set; }
    }
}
