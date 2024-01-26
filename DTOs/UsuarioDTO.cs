namespace AppTransacciones.DTOs
{

    public class UsuarioDTO
    {       
        public string? identificacion { get; set; }
        public string? nombre { get; set; }
        public string? email { get; set; }
        public int idRol { get; set; }
        public string? rolDescripcion { get; set; }
        public string? clave { get; set; }

    }
}
