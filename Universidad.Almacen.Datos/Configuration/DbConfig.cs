using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Datos.Configuration
{
    public class DbConfig
    {
        // tiempo maximo de espera de comando sql
        public const int CommandTimeoutSeconds = 60;
        public const int DefaultPaseSize = 25;
        public const int DefaultPage = 1;
    }
}
