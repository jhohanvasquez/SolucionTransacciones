using AppTransacciones.DTOs;
using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.Utilidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTransacciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IComercioRepositorio _comercioRepositorio;
        public ComercioController(IComercioRepositorio comercioRepositorio, IMapper mapper)
        {
            _mapper = mapper;
            _comercioRepositorio = comercioRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<ComercioDTO>> _response = new Response<List<ComercioDTO>>();

            try
            {
                List<ComercioDTO> ListaComercios = new List<ComercioDTO>();
                IEnumerable<Comercio> query = await _comercioRepositorio.Consultar();
                query = query.AsQueryable();

                ListaComercios = _mapper.Map<List<ComercioDTO>>(query.ToList());

                if (ListaComercios.Count > 0)
                    _response = new Response<List<ComercioDTO>>() { status = true, msg = "ok", value = ListaComercios };
                else
                    _response = new Response<List<ComercioDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<ComercioDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ComercioDTO request)
        {
            Response<ComercioDTO> _response = new Response<ComercioDTO>();
            try
            {
                Comercio _comercio = _mapper.Map<Comercio>(request);

                Comercio _comercioCreado = (Comercio)await _comercioRepositorio.Crear(_comercio);

                if (_comercioCreado.codigo != 0)
                    _response = new Response<ComercioDTO>() { status = true, msg = "ok", value = _mapper.Map<ComercioDTO>(_comercioCreado) };
                else
                    _response = new Response<ComercioDTO>() { status = false, msg = "No se pudo crear el comercio" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<ComercioDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ComercioDTO request)
        {
            Response<ComercioDTO> _response = new Response<ComercioDTO>();
            try
            {
                Comercio _comercio = _mapper.Map<Comercio>(request);
                Comercio _comercioParaEditar = (Comercio)await _comercioRepositorio.Consultar(_comercio.codigo);

                if (_comercioParaEditar != null)
                {

                    _comercioParaEditar.nombre = _comercio.nombre;
                    _comercioParaEditar.nit = _comercio.nit;
                    _comercioParaEditar.direccion = _comercio.direccion;

                    bool respuesta = await _comercioRepositorio.Editar(_comercioParaEditar);

                    if (respuesta)
                        _response = new Response<ComercioDTO>() { status = true, msg = "ok", value = _mapper.Map<ComercioDTO>(_comercioParaEditar) };
                    else
                        _response = new Response<ComercioDTO>() { status = false, msg = "No se pudo editar el comercio" };
                }
                else
                {
                    _response = new Response<ComercioDTO>() { status = false, msg = "No se encontró el comercio" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<ComercioDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }



        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            Response<string> _response = new Response<string>();
            try
            {
                Comercio _comercioEliminar = (Comercio)await _comercioRepositorio.Consultar(id);

                if (_comercioEliminar != null)
                {

                    bool respuesta = await _comercioRepositorio.Eliminar(_comercioEliminar);

                    if (respuesta)
                        _response = new Response<string>() { status = true, msg = "ok", value = "" };
                    else
                        _response = new Response<string>() { status = false, msg = "No se pudo eliminar el comercio", value = "" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<string>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }



    }
}
