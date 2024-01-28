using AppTransacciones.DTOs;
using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class MedioPago
    {
        public MedioPago()
        {
            transacciones = new HashSet<Transaccion>();
        }

        public int idMedio { get; set; }
        public string? descripcion { get; set; }

        public virtual ICollection<Transaccion> transacciones { get; set; }
    }
}
