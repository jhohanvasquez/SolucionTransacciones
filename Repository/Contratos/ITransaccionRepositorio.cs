using AppTransacciones.DTOs;
using AppTransacciones.Models;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Contratos
{
    public interface ITransaccionRepositorio
    {
        Task<Transaccion> Obtener(int id);
        Task<Transaccion> Crear(Transaccion entidad);
    }
}
