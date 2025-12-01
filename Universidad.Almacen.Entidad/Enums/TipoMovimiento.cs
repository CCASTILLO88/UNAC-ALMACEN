using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Entidad.Enums
{
    public enum TipoMovimiento : byte
    {
        Ingreso = (byte)'I',
        Salida = (byte)'S',
        Ajuste = (byte)'A'
    }
}
