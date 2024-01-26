using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class Rol
    {
        public Rol()
        {
            usuarios = new HashSet<Usuario>();
        }

        public int idRol { get; set; }
        public string? descripcion { get; set; }
        public bool? esActivo { get; set; }
        public DateTime? fechaRegistro { get; set; }

        public virtual ICollection<Usuario> usuarios { get; set; }
    }
}
