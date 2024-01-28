using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Implementacion
{
    public class MedioPagoRepositorio : IMedioPagoRepositorio
    {
        private readonly DBTransaccionesContext _context;

        public MedioPagoRepositorio(DBTransaccionesContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<MedioPago>> Lista()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<MedioPago>("SP_ListarMedioPago", null, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
