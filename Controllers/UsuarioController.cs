using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AppTransacciones.Models;
using AppTransacciones.DTOs;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.Utilidades;
using AppTransacciones.Repository.Implementacion;

namespace AppTransacciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IZonaVirtualRepositorio _zonaVirtualRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, IMapper mapper, IZonaVirtualRepositorio zonaVirtualRepositorio)
        {
            _mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
            _zonaVirtualRepositorio = zonaVirtualRepositorio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            Response<List<UsuarioDTO>> _response = new Response<List<UsuarioDTO>>();

            try
            {
                List<UsuarioDTO> ListaUsuarios = new List<UsuarioDTO>();
                var query = await _usuarioRepositorio.Lista();

                ListaUsuarios = _mapper.Map<List<UsuarioDTO>>(query);

                if (ListaUsuarios.Count > 0)
                    _response = new Response<List<UsuarioDTO>>() { status = true, msg = "ok", value = ListaUsuarios };
                else
                    _response = new Response<List<UsuarioDTO>>() { status = false, msg = "", value = null };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<List<UsuarioDTO>>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet]
        [Route("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion(string email, string clave)
        {
            Response<Usuario> _response = new Response<Usuario>();
            try
            {
                Usuario _usuario = await _usuarioRepositorio.Obtener(email, clave);

                if (_usuario != null)
                {
                    var resultConsulta = _zonaVirtualRepositorio.Consultar();
                    if (resultConsulta != null)
                    {
                        _zonaVirtualRepositorio.Save(resultConsulta);
                    }
                    _response = new Response<Usuario>() { status = true, msg = "ok", value = _usuario };
                }
                else
                {
                    _response = new Response<Usuario>() { status = false, msg = "no encontrado", value = null };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<Usuario>() { status = false, msg = ex.Message, value = null };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] UsuarioDTO request)
        {
            Response<UsuarioDTO> _response = new Response<UsuarioDTO>();
            try
            {
                Usuario _usuario = _mapper.Map<Usuario>(request);

                Usuario _usuarioCreado = (Usuario)await _usuarioRepositorio.Crear(_usuario);

                if (_usuarioCreado.usuario_identificacion != "0" && _usuarioCreado.usuario_identificacion != string.Empty)
                    _response = new Response<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuarioCreado) };
                else
                    _response = new Response<UsuarioDTO>() { status = false, msg = "No se pudo crear el usuario" };

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<UsuarioDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO request)
        {
            Response<UsuarioDTO> _response = new Response<UsuarioDTO>();
            try
            {
                Usuario _usuario = _mapper.Map<Usuario>(request);
                Usuario _usuarioParaEditar = await _usuarioRepositorio.Obtener(_usuario.usuario_identificacion);

                if (_usuarioParaEditar != null)
                {

                    _usuarioParaEditar.usuario_nombre = _usuario.usuario_nombre;
                    _usuarioParaEditar.usuario_email = _usuario.usuario_email;
                    _usuarioParaEditar.idRol = _usuario.idRol;
                    _usuarioParaEditar.Clave = _usuario.Clave;

                    bool respuesta = await _usuarioRepositorio.Editar(_usuarioParaEditar);

                    if (respuesta)
                        _response = new Response<UsuarioDTO>() { status = true, msg = "ok", value = _mapper.Map<UsuarioDTO>(_usuarioParaEditar) };
                    else
                        _response = new Response<UsuarioDTO>() { status = false, msg = "No se pudo editar el usuario" };
                }
                else
                {
                    _response = new Response<UsuarioDTO>() { status = false, msg = "No se encontró el usuario" };
                }

                return StatusCode(StatusCodes.Status200OK, _response);
            }
            catch (Exception ex)
            {
                _response = new Response<UsuarioDTO>() { status = false, msg = ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }



        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(string id)
        {
            Response<string> _response = new Response<string>();
            try
            {
                Usuario _usuarioEliminar = await _usuarioRepositorio.Obtener(id);

                if (_usuarioEliminar != null)
                {

                    bool respuesta = await _usuarioRepositorio.Eliminar(_usuarioEliminar);

                    if (respuesta)
                        _response = new Response<string>() { status = true, msg = "ok", value = "" };
                    else
                        _response = new Response<string>() { status = false, msg = "No se pudo eliminar el usuario", value = "" };
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
