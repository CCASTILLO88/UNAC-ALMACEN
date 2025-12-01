using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Datos.Configuration;
using Universidad.Almacen.Datos.Repositories.Interfaces;
using Universidad.Almacen.Datos.Sql;
using Universidad.Almacen.Entidad.Entities;

namespace Universidad.Almacen.Datos.Repositories.Implementations
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        public bool AsignarRolUsuario(int usuarioId, int rolId, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.SEG.Usuario_Rol_Asignar,
                   new
                   {
                       UsuarioId = usuarioId,
                       RolId = rolId,
                       User = user,
                       IP = ip
                   },
                   commandType: CommandType.StoredProcedure,
                   commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public EUsuarioRol ListarRolesPorUsuario(int usuarioId)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var resultado = cn.QueryMultiple(SqlNames.SEG.Usuario_Rol_ListarRolesPorUsuario,
                    new
                    {
                        UsuarioId = usuarioId
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                var usuarioRol = new EUsuarioRol();
                usuarioRol.UsuarioId = usuarioId;
                return usuarioRol;
            }
        }

        public EUsuarioRol ListarUsuariosPorRol(int rolId)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var resultado = cn.QueryMultiple(SqlNames.SEG.Usuario_Rol_ListarUsuariosPorRol,
                    new
                    {
                        RolId = rolId
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                var usuarioRol = new EUsuarioRol();
                usuarioRol.RolId = rolId;
                return usuarioRol;
            }
        }

        public bool RemoverRolUsuario(int usuarioId, int rolId)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.SEG.Usuario_Rol_Remover,
                   new
                   {
                       UsuarioId = usuarioId,
                       RolId = rolId 
                   },
                   commandType: CommandType.StoredProcedure,
                   commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }
    }
}
