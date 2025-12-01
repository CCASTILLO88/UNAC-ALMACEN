using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Common;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Negocio.Interfaces
{
    public interface IUsuarioRol
    {
        Result<bool> AsignarRolUsuario(int usuarioId, int rolId, string user, string ip);
        Result<bool> RemoverRolUsuario(int usuarioId, int rolId);
        Result<EUsuarioRol> ListarRolesPorUsuario(int usuarioId);
        Result<EUsuarioRol> ListarUsuariosPorRol(int rolId);
    }
}