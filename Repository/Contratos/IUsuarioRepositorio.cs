using AppTransacciones.DTOs;
using AppTransacciones.Models;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Contratos
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> Lista();
        Task<Usuario> Obtener(string usuario_email, string clave);
        Task<Usuario> Obtener(string usuario_identificacion);
        Task<IEnumerable<Usuario>> Crear(Usuario entidad);
        Task<IEnumerable<UsuarioDTO>> Crear(UsuarioDTO entidad);
        Task<bool> Editar(Usuario entidad);
        Task<bool> Eliminar(Usuario entidad);
    }
}
