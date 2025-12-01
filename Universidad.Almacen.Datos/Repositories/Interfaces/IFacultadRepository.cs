using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IFacultadRepository
    {
        IEnumerable<EFacultad> ListarFacultades();
        EFacultad ObtenerFacultad(int id);
        int RegistrarFacultad(EFacultad entidad, string user, string ip);
        bool ActualizarFacultad(EFacultad entidad, string user, string ip);
        bool EliminarFacultad(int id, string user, string ip);
    }
}
