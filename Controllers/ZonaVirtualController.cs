using AppTransacciones.DTOs;
using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.Repository.Implementacion;
using AppTransacciones.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace AppTransacciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaVirtualController : ControllerBase
    {
        private readonly IZonaVirtualRepositorio _zonaVirtualRepositorio;

        public ZonaVirtualController(IZonaVirtualRepositorio zonaVirtualRepositorio)
        {
            _zonaVirtualRepositorio = zonaVirtualRepositorio;
        }

        [HttpPost]
        [Route("Consultar")]
        public Task<IActionResult> Consultar()
        {
            Response<UsuarioDTO> _response = new Response<UsuarioDTO>();
            try
            {
                _zonaVirtualRepositorio.Consultar();
                return Task.FromResult<IActionResult>(StatusCode(StatusCodes.Status200OK, _response));
            }
            catch (Exception ex)
            {
                _response = new Response<UsuarioDTO>() { status = false, msg = ex.Message };
                return Task.FromResult<IActionResult>(StatusCode(StatusCodes.Status500InternalServerError, _response));
            }
        }
    }
}
