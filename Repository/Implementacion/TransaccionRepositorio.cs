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
                    var result = await connection.QueryAsync<Transaccion>("SP_ObtenerTransaccionId", parameters, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Transaccion>> ListarTransacciones(string id, int idRol)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();   

                using (var connection = _dbContext.CreateConnection())
                {
                    switch (idRol)
                    {
                        case 1:
                            return await connection.QueryAsync<Transaccion>("SP_ConsultarTransacciones", null, commandType: CommandType.StoredProcedure);                          
                        case 2:
                            parameters.Add("codigoComercio", id);
                            return await connection.QueryAsync<Transaccion>("SP_ObtenerTransaccionComercioId", parameters, commandType: CommandType.StoredProcedure);
                        case 3:
                            parameters.Add("identificacionUsuario", id);
                            return await connection.QueryAsync<Transaccion>("SP_ObtenerTransaccionUsuarioId", parameters, commandType: CommandType.StoredProcedure);
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
