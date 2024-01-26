using AppTransacciones.DTOs;
using AppTransacciones.Models;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Contratos
{
    public interface IComercioRepositorio
    {
        Task<ComercioDTO> Obtener(int id);
        Task<IEnumerable<ComercioDTO>> Crear(ComercioDTO entidad);
    }
}
