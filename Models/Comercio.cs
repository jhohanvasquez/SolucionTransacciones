using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class Comercio
    {
        public int codigo { get; set; }
        public string? nombre { get; set; }
        public string? nit { get; set; }
        public string? direccion { get; set; }
    }
}
