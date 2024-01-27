using AppTransacciones.DTOs;
using AppTransacciones.Models;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Contratos
{
    public interface IComercioRepositorio
    {
        Task<IEnumerable<Comercio>> Crear(Comercio entidad);
        Task<bool> Editar(Comercio entidad);
        Task<bool> Eliminar(Comercio entidad);
        Task<IEnumerable<Comercio>> Consultar();
        Task<Comercio> Consultar(int? idComercio);
    }
}
