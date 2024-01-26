using AppTransacciones.Models;

namespace AppTransacciones.Repository.Contratos
{
    public interface IRolRepositorio
    {
        Task<List<Rol>> Lista();
    }
}
