using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Interfaces
{
    public interface IUsuarioRolRepository
    {
        bool AsignarRolUsuario(int usuarioId, int rolId, string user, string ip);
        bool RemoverRolUsuario(int usuarioId, int rolId);
        EUsuarioRol ListarRolesPorUsuario(int usuarioId);
        EUsuarioRol ListarUsuariosPorRol(int rolId);

    }
}
