using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IProveedorRepository
    {
        IEnumerable<EProveedor> ListarProveedores();
        EProveedor ObtenerProveedor(int id);
        int RegistrarProveedor(EProveedor entidad, string user, string ip);
        bool ActualizarProveedor(EProveedor entidad, string user, string ip);
        bool EliminarProveedor(int id, string user, string ip);
    }
}
