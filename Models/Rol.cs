﻿using System;
using System.Collections.Generic;

namespace AppTransacciones.Models
{
    public partial class Rol
    {
        public Rol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int idRol { get; set; }
        public string? Descripcion { get; set; }
        public bool? EsActivo { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
