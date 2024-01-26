using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AppTransacciones.Models
{
    public partial class DBTransaccionesContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DBTransaccionesContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
          => new SqlConnection(_connectionString);
    }
}
