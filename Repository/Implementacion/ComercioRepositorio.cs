using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;
using System.Data;
using ExpressionExtensionSQL;
using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.DTOs;

namespace AppTransacciones.Repository.Implementacion
{
    public class ComercioRepositorio : IComercioRepositorio
    {
        private readonly DBTransaccionesContext _dbContext;

        public ComercioRepositorio(DBTransaccionesContext dbContext)
        {
            _dbContext = dbContext;
        }
       

        public async Task<IEnumerable<ComercioDTO>> Crear(ComercioDTO entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("codigo", entidad.codigo);
                    parameters.Add("nombre", entidad.nombre);
                    parameters.Add("nit", entidad.nit);
                    parameters.Add("direccion", entidad.direccion);

                    var result = await connection.QueryAsync<ComercioDTO>("SP_CrearComercio", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }          

        public async Task<ComercioDTO> Obtener(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", id);

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<ComercioDTO>("SP_ObtenerComercioId", parameters, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
