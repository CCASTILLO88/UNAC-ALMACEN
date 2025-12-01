using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IPersonaRepository
    {
        IEnumerable<EPersona> ListarPersonas();
        EPersona ObtenerPersona(int id);
        int RegistrarPersona(EPersona entidad, string user, string ip);
        bool ActualizarPersona(EPersona entidad, string user, string ip);
        bool EliminarPersona(int id, string user, string ip);
    }
}
