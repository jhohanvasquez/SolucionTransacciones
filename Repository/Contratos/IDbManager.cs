using Dapper;
using System.Data;

namespace AppTransacciones.Repository.Contratos
{
    public interface IDbManager<T> where T : class
    {
        Task<IEnumerable<T>> GetAllQueryString(string query, object parameters = null);

        Task<int> ExecuteStoreProcedure(string spName, DynamicParameters parameters);

        Task<IEnumerable<object>> ExecuteReaderStoreProcedure(string spName, DataTable dataTable);

        Task<IEnumerable<object>> ExecuteReaderStoreProcedure(string spName, object dataTable);

        Task<IEnumerable<object>> ExecuteReaderStoreProcedure(string spName, DynamicParameters parameters);
    }
}
