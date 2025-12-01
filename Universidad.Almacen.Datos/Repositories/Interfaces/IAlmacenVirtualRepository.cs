using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IAlmacenVirtualRepository
    {
        IEnumerable<EAlmacenVirtual> ListarAlmacenVirtual();
        EAlmacenVirtual ObtenerAlmacenVirtual(int id);
        int RegistrarAlmacenVirtual(EAlmacenVirtual entidad, string user, string ip);
        bool ActualizarAlmacenVirtual(EAlmacenVirtual entidad, string user, string ip);
        bool EliminarAlmacenVirtual(int id, string user, string ip);
    }
}
