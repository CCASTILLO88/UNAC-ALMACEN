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
    public class FacultadRepository : IFacultadRepository
    {
        public bool ActualizarFacultad(EFacultad entidad, string user, string ip)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = connection.Execute(
                    SqlNames.GEO.Facultad_Modificar,
                    new
                    {
                        entidad.FacultadID,
                        entidad.Codigo,
                        entidad.Nombre,
                        entidad.SedeId,
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

        public bool EliminarFacultad(int id, string user, string ip)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = connection.Execute(
                    SqlNames.GEO.Facultad_Eliminar,
                    new { Id = id, User = user, Ip = ip },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public IEnumerable<EFacultad> ListarFacultades()
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                return connection.Query<EFacultad>(
                    SqlNames.GEO.Facultad_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public EFacultad ObtenerFacultad(int id)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                return connection.QueryFirstOrDefault<EFacultad>(
                    SqlNames.GEO.Facultad_Obtener,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public int RegistrarFacultad(EFacultad entidad, string user, string ip)
        {
            using (var connection = ConfigurationFactory.Create().OpenIfClosed())
            {
                var parametros = new DynamicParameters();
                parametros.Add("@Codigo", entidad.Codigo);
                parametros.Add("@Nombre", entidad.Nombre);
                parametros.Add("@SedeId", entidad.SedeId);
                parametros.Add("@Activo", entidad.Activo);
                parametros.Add("@User", user);
                parametros.Add("@Ip", ip);
                parametros.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                connection.Execute(
                    SqlNames.GEO.Facultad_Registrar,
                    parametros,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return parametros.Get<int>("@NewID");
            }
        }
         
    }
}