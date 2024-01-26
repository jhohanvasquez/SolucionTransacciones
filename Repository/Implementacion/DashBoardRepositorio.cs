using AppTransacciones.Models;
using AppTransacciones.Repository.Contratos;
using Dapper;
using System.Data;
using System.Globalization;

namespace AppTransacciones.Repository.Implementacion
{
    public class DashBoardRepositorio : IDashBoardRepositorio
    {
        private readonly DBTransaccionesContext _context;
        public DashBoardRepositorio(DBTransaccionesContext context)
        {
            _context = context;
        }


    }
}
