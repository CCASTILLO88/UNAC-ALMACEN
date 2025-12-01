using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IRolRepository
    { 
        IEnumerable<ERol> ListarRoles();
        ERol ObtenerRol(int id);
        int RegistrarRol(ERol entidad, string user, string ip);
        bool ActualizarRol(ERol entidad, string user, string ip);
        bool EliminarRol(int id, string user, string ip);

    }
}
