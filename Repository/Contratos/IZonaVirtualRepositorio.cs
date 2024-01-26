using AppTransacciones.DTOs;
using AppTransacciones.Models;

namespace AppTransacciones.Repository.Contratos
{
    public interface IZonaVirtualRepositorio
    {
        List<ZonaVirtualDTO> Consultar();
        void Save(List<ZonaVirtualDTO> oListZonaVirtualDTO);
    }
}
