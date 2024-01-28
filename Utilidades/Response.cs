using AppTransacciones.Models;

namespace AppTransacciones.Utilidades
{
    public class Response<T>
    {
        public bool status { get; set; }
        public string? msg { get; set; }
        public T? value { get; set; }

        public static implicit operator Response<T>(Response<Transaccion> v)
        {
            throw new NotImplementedException();
        }
    }
}
