using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class Usuario
    {
        public string? identificacion { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public int? idRol { get; set; }
        public string? clave { get; set; }
        public bool? esActivo { get; set; }

        public virtual Rol? idRolNavigation { get; set; }
    }
}
