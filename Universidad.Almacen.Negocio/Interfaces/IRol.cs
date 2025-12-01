using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Common;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Negocio.Interfaces
{
    public interface IRol
    {
        Result<IEnumerable<ERol>> Listar();
        Result Actualizar(ERol entidad, string user, string ip);
        Result Eliminar(int id, string user, string ip);
        Result <int> Registrar(ERol entidad, string user, string ip);
        Result<ERol> Obtener(int id);

    }
}
