using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AppTransacciones.Models
{
    public partial class APITransaccionesContext
    {

        private readonly IConfiguration _configuration;
        public readonly string _serviceUrl;
        public readonly string _consultaEndPoint;

        public APITransaccionesContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceUrl = _configuration.GetConnectionString("ServiceUrl");
            _consultaEndPoint = _configuration.GetConnectionString("ConsultaEndPoint");
        }

    }
}
