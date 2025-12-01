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
    public class RolRepository : IRolRepository
    {
        public bool ActualizarRol(ERol entidad, string user, string ip)
        {
            using (var db = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = db.Execute(
                    SqlNames.SEG.Rol_Modificar,
                    new
                    {
                        entidad.RolId,
                        entidad.Nombre,
                        entidad.Activo,
                        User = user,
                        IP = ip,
                        Rowversion = entidad.RowVersion
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public bool EliminarRol(int id, string user, string ip)
        {
            using (var db = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = db.Execute(
                    SqlNames.SEG.Rol_Eliminar,
                    new
                    {
                        RolId = id,
                        User = user,
                        IP = ip
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public IEnumerable<ERol> ListarRoles()
        {
            using (var db = ConfigurationFactory.Create().OpenIfClosed())
            {
                return db.Query<ERol>(
                    SqlNames.SEG.Rol_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public ERol ObtenerRol(int id)
        {
            using (var db = ConfigurationFactory.Create().OpenIfClosed())
            {
                return db.QueryFirstOrDefault<ERol>(
                    SqlNames.SEG.Rol_Obtener,
                    new { RolId = id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public int RegistrarRol(ERol entidad, string user, string ip)
        {
            using (var db = ConfigurationFactory.Create().OpenIfClosed())
            {
                var p = new DynamicParameters();
                p.Add("@Nombre", entidad.Nombre); 
                p.Add("@Activo", entidad.Activo);
                p.Add("@User", user);
                p.Add("@Ip", ip);
                p.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                db.Execute(SqlNames.SEG.Rol_Registrar, p, commandType: CommandType.StoredProcedure, commandTimeout: DbConfig.CommandTimeoutSeconds);
                return p.Get<int>("@NewID");
            }
        }
    }
}
