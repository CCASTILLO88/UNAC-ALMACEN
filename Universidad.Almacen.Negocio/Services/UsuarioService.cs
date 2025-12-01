using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Common;
using Universidad.Almacen.Negocio.Interfaces;
using Universidad.Almacen.Entidad.Entities;
using Universidad.Almacen.Datos.Repositories.Interfaces;

namespace Universidad.Almacen.Negocio.Services
{
    public class UsuarioService : IUsuario
    {
        private readonly IUsuarioRepository _repo;
        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }
        public Result ActualizarUsuario(EUsuario entidad, string user, string ip)
        {
            Guard.POSTIVO(entidad.UsuarioId, "ID Invalido");
            var ok = _repo.ActualizarUsuario(entidad, user, ip);
            return ok ? Result.Success("Usuario Actualizado")
                      : Result.Failure("Error al actualizar Usuario");
        }

        public Result CambiarContrasena(int usuarioId, byte[] hassPassActual, byte[] hassPassNuevo, string user, string ip)
        {
            Guard.POSTIVO(usuarioId, "ID Invalido");
            Guard.NOTNULL(hassPassActual, "Contraseña Actual Requerida");
            Guard.NOTNULL(hassPassNuevo, "Contraseña Nueva Requerida");
            var ok = _repo.CambiarContrasena(usuarioId, hassPassActual, hassPassNuevo, user, ip);
            return ok ? Result.Success("Contraseña Actualizada")
                      : Result.Failure("Error al actualizar Contraseña");
        }

        public Result EliminarUsuario(int id, string user, string ip)
        {
            Guard.POSTIVO(id, "ID Invalido");
            var ok = _repo.EliminarUsuario(id, user, ip);
            return ok ? Result.Success("Usuario Eliminado")
                      : Result.Failure("Error al eliminar Usuario");
        }

        public Result<IEnumerable<EUsuario>> ListarUsuarios()
        {
            var data = _repo.ListarUsuarios() ?? Enumerable.Empty<EUsuario>();
            return Result<IEnumerable<EUsuario>>.Success(data);
        }

        public Result<EUsuario> ObtenerUsuario(int id)
        {
            Guard.POSTIVO(id, "ID Invalido");
            var e = _repo.ObtenerUsuario(id);
            return e == null ? Result<EUsuario>.Failure("Usuario no encontrado")
                             : Result<EUsuario>.Success(e);
        }

        public Result<int> RegistrarUsuario(EUsuario entidad, string user, string ip)
        {
            Guard.NOTNULL(entidad, "Entidad Requerida");
            var id = _repo.RegistrarUsuario(entidad, user, ip);
            return id > 0 ? Result<int>.Success(id, "Usuario Registrado")
                          : Result<int>.Failure("Error al registrar Usuario");
        }

        public Result<EUsuario> ValidarUsuario(string username, byte[] hashPass)
        {
            Guard.NOTEMPTY(username, "Username Requerido");
            Guard.NOTNULL(hashPass, "HashPass Requerido");
            var e = _repo.ValidarUsuario(username, hashPass);
            return e == null ? Result<EUsuario>.Failure("Usuario no encontrado")
                             : Result<EUsuario>.Success(e);
        }
    }
}
