using AppTransacciones.DTOs;
using AppTransacciones.Models;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Contratos
{
    public interface ITransaccionRepositorio
    {
        Task<TransaccionDTO> Obtener(string id);
        Task<IEnumerable<TransaccionDTO>> Crear(TransaccionDTO entidad);
    }
}
