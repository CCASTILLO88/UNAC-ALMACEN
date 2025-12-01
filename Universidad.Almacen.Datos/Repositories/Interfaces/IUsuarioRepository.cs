using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        IEnumerable<EUsuario> ListarUsuarios();
        EUsuario ObtenerUsuario(int id);
        EUsuario ValidarUsuario(string username, byte[] hashPass);
        int RegistrarUsuario(EUsuario entidad, string user, string ip);
        bool ActualizarUsuario(EUsuario entidad, string user, string ip);
        bool EliminarUsuario(int id, string user, string ip);
        bool CambiarContrasena(int usuarioId, byte[] hassPassActual, byte[] hassPassNuevo, string user, string ip);
    }
}
