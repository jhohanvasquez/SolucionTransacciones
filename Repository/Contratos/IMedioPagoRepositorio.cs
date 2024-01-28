using AppTransacciones.Models;

namespace AppTransacciones.Repository.Contratos
{
    public interface IMedioPagoRepositorio
    {
        Task<List<MedioPago>> Lista();
    }
}
