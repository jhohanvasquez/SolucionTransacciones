using AppTransacciones.DTOs;
using AppTransacciones.Models;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Contratos
{
    public interface ITransaccionRepositorio
    {
        Task<Transaccion> Obtener(string id);
        Task<IEnumerable<Transaccion>> Crear(Transaccion entidad);
    }
}
