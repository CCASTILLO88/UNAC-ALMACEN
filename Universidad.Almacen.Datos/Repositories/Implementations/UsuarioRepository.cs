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
    public class UsuarioRepository : IUsuarioRepository
    {
        public bool ActualizarUsuario(EUsuario entidad, string user, string ip)
        { 
            using (var con = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = con.Execute(SqlNames.SEG.Usuario_Modificar,
                   new
                   {
                       entidad.UsuarioId,
                       entidad.PersonaId,
                       entidad.Username,
                       entidad.Email,
                       entidad.Activo,
                       User = user,
                       IP = ip,
                       RowVersion = entidad.RowVersion
                   },
                   commandType: CommandType.StoredProcedure,
                   commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public bool CambiarContrasena(int usuarioId, byte[] hassPassActual, byte[] hassPassNuevo, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.SEG.Usuario_CambiarClave,
                   new
                   {
                       UsuarioId = usuarioId,
                       HashPassActual = hassPassActual,
                       HashPassNuevo = hassPassNuevo,
                       User = user,
                       IP = ip
                   },
                   commandType: CommandType.StoredProcedure,
                   commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public bool EliminarUsuario(int id, string user, string ip)
        { 
            using (var con = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = con.Execute(SqlNames.SEG.Usuario_Eliminar,
                   new
                   {
                       UsuarioId = id,
                       User = user,
                       IP = ip
                   },
                   commandType: CommandType.StoredProcedure,
                   commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public IEnumerable<EUsuario> ListarUsuarios()
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                return connection.Query<EUsuario>(
                    SqlNames.SEG.Usuario_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public EUsuario ObtenerUsuario(int id)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                return connection.QueryFirstOrDefault<EUsuario>(
                    SqlNames.SEG.Usuario_Obtener,
                    new { UsuarioId = id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public int RegistrarUsuario(EUsuario entidad, string user, string ip)
        {
            using (var con = ConfigurationFactory.Create().OpenIfClosed())
            {
                var p = new DynamicParameters();
                p.Add("@PersonaId", entidad.PersonaId);
                p.Add("@Username", entidad.Username);
                p.Add("@Email", entidad.Email);
                p.Add("@HashPass", entidad.HashPass, DbType.Binary, size: entidad.HashPass?.Length ?? 0);
                p.Add("@Activo", entidad.Activo);
                p.Add("@User", user);
                p.Add("@Ip", ip);
                p.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                con.Execute(SqlNames.SEG.Usuario_Registrar, p, commandType: CommandType.StoredProcedure, commandTimeout: DbConfig.CommandTimeoutSeconds);
                return p.Get<int>("@NewID");
            } 
        }

        public EUsuario ValidarUsuario(string username, byte[] hashPass)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                using (var multi = connection.QueryMultiple(
                    SqlNames.SEG.Usuario_ValidarAcceso,
                    new
                    {
                        Username = username,
                        HashPass = hashPass
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds))
                {
                    
                    var usuario = multi.ReadFirstOrDefault<EUsuario>();
                    if (usuario == null)
                        return null;

                    
                    var roles = multi.Read<(int RolId, string Nombre)>()  
                                     .Select(r => r.Nombre)
                                     .ToList();

                    usuario.Roles = roles;
                    return usuario;
                }
            }
        }
    }
}
