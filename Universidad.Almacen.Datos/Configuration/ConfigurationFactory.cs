using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Datos.Configuration
{
    public class ConfigurationFactory
    {
        public static IDbConnection Create() 
        {
            var cs = ConfigurationManager.ConnectionStrings["AlmacenDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
