using AppTransacciones.DTOs;
using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.Repository.Implementacion;
using AppTransacciones.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppTransacciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ITransaccionRepositorio _transaccionRepositorio;

        public TransaccionController(ITransaccionRepositorio transaccionRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _transaccionRepositorio = transaccionRepositorio;
        }

        [HttpGet]
        [Route("Consultar/{id:int}")]
        public async Task<IActionResult> Consultar(int id)
        {
            Response<string> _response = new Response<string>();
            try
            {
                Transaccion oTransaccion = new Transaccion();
                Transaccion _transaccionConsulta = await _transaccionRepositorio.Obtener(id);

                if (_transaccionConsulta != null)
                {
                    _response = new Response<string>() { status = true, msg = "ok", value = _transaccionConsulta.estado.ToString() };
                }
                else
                {
                    _response = new Response<string>() { status = false, msg = "sin resultados", value = null };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [Route("ConsultarTransacciones/{id}/{idRol:int}")]
        public async Task<IActionResult> ConsultarTransaccionComercio(string id, int idRol)
        {
            Response<List<TransaccionDTO>> _response = new Response<List<TransaccionDTO>>();
            try
            {
                List<TransaccionDTO> ListaTransacciones = new List<TransaccionDTO>();
                IEnumerable<Transaccion> query = await _transaccionRepositorio.ListarTransacciones(id, idRol);
                query = query.AsQueryable();

                ListaTransacciones = _mapper.Map<List<TransaccionDTO>>(query.ToList());

                if (ListaTransacciones.Count > 0)
                {
                    _response = new Response<List<TransaccionDTO>> () { status = true, msg = "ok", value = ListaTransacciones };
                }
                else
                {
                    _response = new Response<List<TransaccionDTO>>() { status = false, msg = "sin resultados", value = null };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<TransaccionDTO>>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] TransaccionDTO request)
        {
            Response<TransaccionDTO> _response = new Response<TransaccionDTO>();
            try
            {
                var resultRequest = _mapper.Map<Transaccion>(request);
                var transaccion_creada = await _transaccionRepositorio.Crear(resultRequest);
                _response = new Response<TransaccionDTO>() { status = true, msg = "ok", value = request };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<TransaccionDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }


    }
}
