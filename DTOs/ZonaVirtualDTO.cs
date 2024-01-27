using AppTransacciones.Models;

namespace AppTransacciones.DTOs
{
    public class ZonaVirtualDTO
    {
        public Comercio? comercio { get; set; }
        public Transaccion? Trans { get; set; }
        public Usuario? usuario { get; set; }
    }
}
