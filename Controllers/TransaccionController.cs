using AppTransacciones.DTOs;
using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
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


        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] TransaccionDTO request)
        {
            Response<TransaccionDTO> _response = new Response<TransaccionDTO>();
            try
            {
                var resultRequest = _mapper.Map<Transaccion>(request);
                Transaccion transaccion_creada = await _transaccionRepositorio.Crear(resultRequest);
                request = _mapper.Map<TransaccionDTO>(transaccion_creada);
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
