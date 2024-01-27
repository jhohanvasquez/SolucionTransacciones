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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DBTransaccionesContext _dbContext;

        public UsuarioRepositorio(DBTransaccionesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
        {
            var query = $@"SELECT * FROM [Usuarios]
                            {{where}}";

            using (var connection = _dbContext.CreateConnection())
            {
                var list = await connection.QueryAsync<Usuario>(query, filtro);
                return list;
            }
        }

        public async Task<IEnumerable<UsuarioDTO>> Crear(UsuarioDTO entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("identificacion", entidad.identificacion);
                    parameters.Add("nombre", entidad.nombre);
                    parameters.Add("email", entidad.email);
                    parameters.Add("idRol", entidad.idRol == 0 ? 4 : entidad.idRol);
                    parameters.Add("clave", entidad.clave ?? string.Empty);
                    parameters.Add("EsActivo", true);

                    var result = await connection.QueryAsync<UsuarioDTO>("SP_CrearUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> Crear(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("identificacion", entidad.identificacion);
                    parameters.Add("nombre", entidad.nombre);
                    parameters.Add("email", entidad.email);
                    parameters.Add("idRol", entidad.idRol ?? 4);
                    parameters.Add("clave", entidad.clave ?? string.Empty);
                    parameters.Add("esActivo", true);

                    var result = await connection.QueryAsync<Usuario>("SP_CrearUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("identificacion", entidad.identificacion);
                    parameters.Add("nombre", entidad.nombre);
                    parameters.Add("email", entidad.email);
                    parameters.Add("idRol", entidad.idRol);
                    parameters.Add("clave", entidad.clave);
                    parameters.Add("EsActivo", entidad.esActivo);

                    var result = await connection.QueryAsync<Usuario>("SP_EditarUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }

            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("identificacion", entidad.identificacion);

                    var result = await connection.QueryAsync<Usuario>("SP_EliminarUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> Lista()
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    return await connection.QueryAsync<Usuario>("SP_ListarUsuario", null, commandType: CommandType.StoredProcedure);

                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<Usuario> Obtener(string usuario_email, string clave)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("email", usuario_email);
                parameters.Add("clave", clave);

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<Usuario>("SP_ObtenerUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Usuario> Obtener(string id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("identificacion", id);

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<Usuario>("SP_ObtenerUsuarioId", parameters, commandType: CommandType.StoredProcedure);

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
