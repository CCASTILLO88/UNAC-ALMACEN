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
    public class UsuarioRolService : IUsuarioRol
    {
        private readonly IUsuarioRolRepository _repo;
        public UsuarioRolService(IUsuarioRolRepository repo)
        {
            _repo = repo;
        }

        Result<bool> IUsuarioRol.AsignarRolUsuario(int usuarioId, int rolId, string user, string ip)
        {
            Guard.NOTEMPTY(usuarioId.ToString(), "Usuario ID Requerido");
            Guard.NOTEMPTY(rolId.ToString(), "Rol ID Requerido");
            Guard.NOTEMPTY(user, "Usuario Requerido");
            Guard.NOTEMPTY(ip, "IP Requerida");


            var ok = _repo.AsignarRolUsuario(usuarioId, rolId, user, ip);
            return ok ? Result<bool>.Success(true, "Rol asignado al usuario") 
                      : Result<bool>.Failure("Error al asignar rol al usuario");
        }

        Result<EUsuarioRol> IUsuarioRol.ListarRolesPorUsuario(int usuarioId)
        {
            Guard.POSTIVO(usuarioId, "Usuario ID Invalido");
            Guard.NOTEMPTY(usuarioId.ToString(), "Usuario ID Requerido");
            var ok = _repo.ListarRolesPorUsuario(usuarioId);
            return ok != null ? Result<EUsuarioRol>.Success(ok, "Roles obtenidos para el usuario") 
                             : Result<EUsuarioRol>.Failure("Error al obtener roles para el usuario");
        }

        Result<EUsuarioRol> IUsuarioRol.ListarUsuariosPorRol(int rolId)
        {
            Guard.POSTIVO(rolId, "Rol ID Invalido");
            Guard.NOTEMPTY(rolId.ToString(), "Rol ID Requerido");
            var ok = _repo.ListarUsuariosPorRol(rolId);
            return ok != null ? Result<EUsuarioRol>.Success(ok, "Usuarios obtenidos para el rol") 
                             : Result<EUsuarioRol>.Failure("Error al obtener usuarios para el rol");
        }

        Result<bool> IUsuarioRol.RemoverRolUsuario(int usuarioId, int rolId)
        {
            Guard.NOTEMPTY(usuarioId.ToString(), "Usuario ID Requerido");
            Guard.NOTEMPTY(rolId.ToString(), "Rol ID Requerido");
            var ok = _repo.RemoverRolUsuario(usuarioId, rolId);
            return ok ? Result<bool>.Success(true, "Rol removido del usuario") 
                      : Result<bool>.Failure("Error al remover rol del usuario");
        }
    }
}
