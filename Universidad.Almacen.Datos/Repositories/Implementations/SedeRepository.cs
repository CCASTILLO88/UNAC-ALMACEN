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
    public class SedeRepository : ISedeRepository
    {
        public bool ActualizarSede(ESede entidad, string user, string ip)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = connection.Execute(
                    SqlNames.GEO.Sede_Modificar,
                    new
                    {
                        entidad.SedeId,
                        entidad.Codigo,
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
         
        public bool EliminarSede(int id, string user, string ip)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = connection.Execute(
                    SqlNames.GEO.Sede_Eliminar,
                    new { Id = id, User = user, Ip = ip },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public IEnumerable<ESede> ListarSedes()
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                return connection.Query<ESede>(
                    SqlNames.GEO.Sede_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public ESede ObtenerSede(int id)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                return connection.QueryFirstOrDefault<ESede>(
                    SqlNames.GEO.Sede_Obtener,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public int RegistrarSede(ESede entidad, string user, string ip)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
               var P = new DynamicParameters();
                P.Add("@Codigo", entidad.Codigo);
                P.Add("@Nombre", entidad.Nombre);
                P.Add("@Activo", entidad.Activo);
                P.Add("@User", user);
                P.Add("@Ip", ip);
                P.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);

                connection.Execute("GEO.USP_REGISTRAR_SEDE", P, commandType: CommandType.StoredProcedure, commandTimeout: DbConfig.CommandTimeoutSeconds);
                return P.Get<int>("@NewID");
            }
        }

    }
}
