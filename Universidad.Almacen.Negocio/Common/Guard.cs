using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Negocio.Common
{
    public class Guard
    {
        public static void NOTNULL(object obj, string msg)
        {
            if (obj == null)
            {
                throw new ValidationException(msg);
            }
        }

        public static void NOTEMPTY(string str, string msg)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ValidationException(msg);
            }
        }

        public static void MAXLENGTH(string str, int maxLength, string msg)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > maxLength)
            {
                throw new ValidationException(msg);
            }

            //if (s != null && s.Trim().Length > max) throw new ValidationException(msg);
        }

        public static void POSTIVO(int number, string msg)
        {
            if (number <= 0)
            {
                throw new ValidationException(msg);
            }
        }
    }
}
