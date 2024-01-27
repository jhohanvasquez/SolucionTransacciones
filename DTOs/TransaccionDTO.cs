namespace AppTransacciones.DTOs
{
    public class Transaccion
    {
        public string? codigo { get; set; }
        public int medio_pago { get; set; }
        public int estado { get; set; }
        public double total { get; set; }
        public string? fecha { get; set; }
        public string? concepto { get; set; }
        public string? identificacionUsuario { get; set; }
        public int codigoComercio { get; set; }
    }
}
