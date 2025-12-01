using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Common;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Negocio.Interfaces
{
    public interface IUnidadMedida
    {
        Result<IEnumerable<EUnidadMedida>> Listar();

        Result<EUnidadMedida> Obtener(int id);

        Result<int> Registrar(EUnidadMedida entidad, string user, string ip);

        Result Actualizar(EUnidadMedida entidad, string user, string ip);

        Result Eliminar(int id, string user, string ip);
        
        bool ExisteActiva(int id);

    }
}
