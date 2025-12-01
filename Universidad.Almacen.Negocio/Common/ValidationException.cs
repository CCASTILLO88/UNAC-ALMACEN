using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Negocio.Common
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }

    public class ConcurrencyException : Exception
    {
        public ConcurrencyException(string message) : base(message)
        {
        }
    }
}
