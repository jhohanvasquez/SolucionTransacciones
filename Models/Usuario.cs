using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class Usuario
    {
        public string? usuario_identificacion { get; set; }
        public string? usuario_nombre { get; set; }
        public string? usuario_email { get; set; }
        public int? idRol { get; set; }
        public string? Clave { get; set; }
        public bool? EsActivo { get; set; }

        public virtual Rol? idRolNavigation { get; set; }
    }
}
