using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Datos.Configuration
{
    public static class ConnectionExtensions
    {
        public static IDbConnection OpenIfClosed(this IDbConnection connection )
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
    }
}
