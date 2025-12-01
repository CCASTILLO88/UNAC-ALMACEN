using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface ISedeRepository
    {
        IEnumerable<ESede> ListarSedes();
        ESede ObtenerSede(int id);
        int RegistrarSede(ESede entidad, string user, string ip);
        bool ActualizarSede(ESede entidad, string user, string ip);
        bool EliminarSede(int id, string user, string ip);

    }
} 