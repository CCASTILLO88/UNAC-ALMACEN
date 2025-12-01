using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Common;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Negocio.Interfaces
{
    public interface IPersona
    {
        Result<IEnumerable<EPersona>> Listar();
        Result<EPersona> Obtener(int id);
        Result<int> Registrar(EPersona entidad, string user, string ip);
        Result Actualizar(EPersona entidad, string user, string ip);
        Result Eliminar(int id, string user, string ip);
    }
}
