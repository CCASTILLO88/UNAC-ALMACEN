using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Common;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Negocio.Interfaces
{
    public interface IUsuario
    {
        Result<IEnumerable<EUsuario>> ListarUsuarios();
        Result<EUsuario> ObtenerUsuario(int id);
        Result<EUsuario> ValidarUsuario(string username, byte[] hashPass);
        Result<int> RegistrarUsuario(EUsuario entidad, string user, string ip);
        Result ActualizarUsuario(EUsuario entidad, string user, string ip);
        Result EliminarUsuario(int id, string user, string ip);
        Result CambiarContrasena(int usuarioId, byte[] hassPassActual, byte[] hassPassNuevo, string user, string ip);

    }
}
