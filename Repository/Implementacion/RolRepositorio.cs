using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace AppTransacciones.Repository.Implementacion
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly DBTransaccionesContext _context;

        public RolRepositorio(DBTransaccionesContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Rol>> Lista()
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    var result = await connection.QueryAsync<Rol>("SP_ListarUsuario", null, commandType: CommandType.StoredProcedure);
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
