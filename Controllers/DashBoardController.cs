using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AppTransacciones.Repository.Contratos;
using AppTransacciones.DTOs;
using AppTransacciones.Utilidades;

namespace AppTransacciones.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBoardRepositorio _dashboardRepositorio;
        public DashBoardController(IDashBoardRepositorio dashboardRepositorio)
        {
            _dashboardRepositorio = dashboardRepositorio;
        }

       
    }
}
