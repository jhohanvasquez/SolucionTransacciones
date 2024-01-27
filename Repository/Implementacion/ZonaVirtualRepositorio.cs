using AppTransacciones.DTOs;
using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using Dapper;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AppTransacciones.Repository.Implementacion
{
    public class ZonaVirtualRepositorio : IZonaVirtualRepositorio
    {
        private readonly APITransaccionesContext _dbcontext;
        private readonly IComercioRepositorio _comercioRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ITransaccionRepositorio _transaccionRepositorio;

        public ZonaVirtualRepositorio(APITransaccionesContext context, IComercioRepositorio comercioRepositorio, IUsuarioRepositorio usuarioRepositorio, ITransaccionRepositorio transaccionRepositorio)
        {
            _dbcontext = context;
            _comercioRepositorio = comercioRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _transaccionRepositorio = transaccionRepositorio;

        }

        public void Save(List<ZonaVirtualDTO> oListZonaVirtualDTO)
        {
            var resultComercio = Parallel.ForEach(oListZonaVirtualDTO, async item =>
            {
                if (item.comercio != null)
                {
                    var resutlComercio = await _comercioRepositorio.Consultar(item.comercio.codigo);
                    if (resutlComercio == null)
                    {
                        await _comercioRepositorio.Crear(item.comercio);
                    }
                }

                if (item.usuario != null)
                {
                    var resultUsuario = await _usuarioRepositorio.Obtener(item.usuario.identificacion);
                    if (resultUsuario == null)
                    {
                        await _usuarioRepositorio.Crear(item.usuario);
                    }
                }

                if (item.Trans != null && item.comercio != null)
                {
                    var resutlComercio = await _comercioRepositorio.Consultar(item.comercio.codigo);
                    if (resutlComercio != null)
                    {
                        var resutTransaccion = await _transaccionRepositorio.Obtener(item.Trans.codigo);
                        if (resutTransaccion == null)
                        {
                            await _transaccionRepositorio.Crear(item.Trans);
                        }
                    }
                }

            });

        }


        public List<ZonaVirtualDTO> Consultar()
        {

            try
            {

                var client = new RestClient(_dbcontext._serviceUrl);

                var request = new RestRequest(_dbcontext._consultaEndPoint, Method.POST);
                request.AddHeader("Content-Type", "application/json");
                int tryCounter = 0;
                IRestResponse<List<ZonaVirtual>> response;
                do
                {
                    response = client.Execute<List<ZonaVirtual>>(request);
                    tryCounter++;
                }
                while (response.StatusCode != HttpStatusCode.OK && tryCounter < 10);

                var resultApi = MapTransacciones(response.Data);

                return resultApi;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<ZonaVirtualDTO> MapTransacciones(List<ZonaVirtual> responseZonaVirtual)
        {
            List<ZonaVirtualDTO> zonaVirtualDTOs = new List<ZonaVirtualDTO>();

            foreach (var itemZonaVirtual in responseZonaVirtual)
            {
                ZonaVirtualDTO oZonaVirtualDTOs = new ZonaVirtualDTO();

                oZonaVirtualDTOs.usuario = new Usuario
                {
                    identificacion = itemZonaVirtual.usuario_identificacion,
                    email = itemZonaVirtual.usuario_email,
                    nombre = itemZonaVirtual.usuario_nombre
                };

                oZonaVirtualDTOs.comercio = new Comercio
                {
                    codigo = itemZonaVirtual.comercio_codigo,
                    nombre = itemZonaVirtual.comercio_nombre,
                    nit = itemZonaVirtual.comercio_nit,
                    direccion = itemZonaVirtual.comercio_direccion
                };

                oZonaVirtualDTOs.Trans = new Transaccion
                {
                    codigo = itemZonaVirtual.Trans_codigo,
                    medio_pago = itemZonaVirtual.Trans_medio_pago,
                    estado = itemZonaVirtual.Trans_estado,
                    total = itemZonaVirtual.Trans_total,
                    fecha = itemZonaVirtual.Trans_fecha,
                    concepto = itemZonaVirtual.Trans_concepto,
                    identificacionUsuario = itemZonaVirtual.usuario_identificacion,
                    codigoComercio = itemZonaVirtual.comercio_codigo
                };

                zonaVirtualDTOs.Add(oZonaVirtualDTOs);
            }

            return zonaVirtualDTOs;
        }
    }
}
