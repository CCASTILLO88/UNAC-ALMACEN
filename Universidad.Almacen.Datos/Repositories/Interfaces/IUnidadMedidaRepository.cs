using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IUnidadMedidaRepository
    {
        IEnumerable<EUnidadMedida> Listar();
        EUnidadMedida Obtener(int id);
        int Registrar(EUnidadMedida entidad, string user, string ip);
        bool Actualizar(EUnidadMedida entidad, string user, string ip);
        bool Eliminar(int id, string user, string ip);

    }
}
