using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IAlmacenRepository
    {
        IEnumerable<EAlmacen> ListarAlmacenes();
        EAlmacen ObtenerAlmacen(int id);
        int RegistrarAlmacen(EAlmacen entidad, string user, string ip);
        bool ActualizarAlmacen(EAlmacen entidad, string user, string ip);
        bool EliminarAlmacen(int id, string user, string ip);
    }
}
