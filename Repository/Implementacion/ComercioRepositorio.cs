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
        private readonly DBTransaccionesContext _context;

        public ComercioRepositorio(DBTransaccionesContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Comercio>> Consultar()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Comercio>("SP_ConsultarComercios", null, commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<Comercio> Consultar(int? codigo)
        {
            using (var connection = _context.CreateConnection())
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("codigo", codigo);

                var result = await connection.QueryAsync<Comercio>("SP_ConsultarComerciosId", parameters, commandType: CommandType.StoredProcedure);

                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Comercio>> Crear(Comercio entidad)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("nombre", entidad.nombre);
                    parameters.Add("nit", entidad.nit);
                    parameters.Add("direccion", entidad.direccion);

                    return await connection.QueryAsync<Comercio>("SP_CrearComercio", parameters, commandType: CommandType.StoredProcedure);

                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Comercio entidad)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {


                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("codigo", entidad.codigo);
                    parameters.Add("nombre", entidad.nombre);
                    parameters.Add("nit", entidad.nit);
                    parameters.Add("direccion", entidad.direccion);

                    var result = await connection.QueryAsync<Comercio>("SP_EditarComercio", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Comercio entidad)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("codigo", entidad.codigo);

                    var result = await connection.QueryAsync<Usuario>("SP_EliminarComercio", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

