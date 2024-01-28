using AppTransacciones.DTOs;
using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.Repository.Implementacion;
using AppTransacciones.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
        [Route("Consultar/{codigo:int}")]
        public async Task<IActionResult> Consultar(int codigo)
        {
            Response<string> _response = new Response<string>();
            try
            {
                Transaccion _transaccionConsulta = await _transaccionRepositorio.Obtener(codigo);

                if (_transaccionConsulta != null)
                {
                    _response = new Response<Transaccion>() { status = true, msg = "ok", value = _transaccionConsulta };
                }
                else
                {
                    _response = new Response<Transaccion>() { status = false, msg = "sin resultados", value = null };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<string>() { status = false, msg = ex.Message };
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
