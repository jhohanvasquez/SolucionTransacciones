using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AppTransacciones.DTOs;
using AppTransacciones.Utilidades;
using AppTransacciones.Repository.Contratos;

namespace AppTransacciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioPagoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMedioPagoRepositorio _rolRepositorio;
        public MedioPagoController(IMedioPagoRepositorio rolRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _rolRepositorio = rolRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<MedioPagoDTO>> _response = new Response<List<MedioPagoDTO>>();

            try
            {
                List<MedioPagoDTO> _listaMedioPagoes = new List<MedioPagoDTO>();
                _listaMedioPagoes = _mapper.Map<List<MedioPagoDTO>>(await _rolRepositorio.Lista());

                if (_listaMedioPagoes.Count > 0)
                    _response = new Response<List<MedioPagoDTO>>() { status = true, msg = "ok", value = _listaMedioPagoes };
                else
                    _response = new Response<List<MedioPagoDTO>>() { status = false, msg = "sin resultados", value = null };


                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<MedioPagoDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }
    }
}
