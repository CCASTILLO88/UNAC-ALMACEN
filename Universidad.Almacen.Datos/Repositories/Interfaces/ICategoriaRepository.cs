using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<ECategoria> ListarCategorias();
        ECategoria ObtenerCategoria(int id);
        int RegistrarCategoria(ECategoria entidad, string user, string ip);
        bool ActualizarCategoria(ECategoria entidad, string user, string ip);
        bool EliminarCategoria(int id, string user, string ip);

    }
}
