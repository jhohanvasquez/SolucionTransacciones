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
    public class TransaccionRepositorio : ITransaccionRepositorio
    {
        private readonly DBTransaccionesContext _dbContext;

        public TransaccionRepositorio(DBTransaccionesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comercio> Consultar(int? codigo)
        {
            using (var connection = _dbContext.CreateConnection())
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo);

                var result = await connection.QueryAsync<Comercio>("SP_ObtenerTransaccionId", parameters, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Transaccion>> Crear(Transaccion entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("codigo", entidad.codigo);
                    parameters.Add("medio_pago", entidad.medio_pago == 0 ? 5 : entidad.medio_pago);
                    parameters.Add("estado", entidad.estado == 0 ? 5 : 3);
                    parameters.Add("total", entidad.total);
                    parameters.Add("fecha", DateTime.Now.ToString());
                    parameters.Add("concepto", entidad.concepto);
                    parameters.Add("identificacionUsuario", entidad.identificacionUsuario);
                    parameters.Add("codigoComercio", entidad.codigoComercio);

                    var result = await connection.QueryAsync<Transaccion>("SP_CrearTransaccion", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Transaccion> Obtener(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", id);

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<Transaccion>("SP_ObtenerComercioId", parameters, commandType: CommandType.StoredProcedure);

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
