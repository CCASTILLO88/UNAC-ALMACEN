using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Datos.Repositories.Interfaces;
using Universidad.Almacen.Entidad.Entities;
using Dapper;
using Universidad.Almacen.Datos.Configuration;
using System.Data;
using Universidad.Almacen.Datos.Sql;

namespace Universidad.Almacen.Datos.Repositories.Implementations
{
    public class UnidadMedidaRepository : IUnidadMedidaRepository
    {
        public IEnumerable<EUnidadMedida> Listar()
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                return cn.Query<EUnidadMedida>(
                    SqlNames.MAE.UnidadMedida_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public EUnidadMedida Obtener(int id)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                return cn.QueryFirstOrDefault<EUnidadMedida>(
                    SqlNames.MAE.UnidadMedida_Obtener,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public int Registrar(EUnidadMedida entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed()) 
            {
                var p = new DynamicParameters();
                p.Add("@Codigo", entidad.Codigo);
                p.Add("@Nombre", entidad.Nombre);
                p.Add("@Activo", entidad.Activo);
                p.Add("@User", user);
                p.Add("@Ip", ip);
                p.Add("@NewID", dbType:DbType.Int64, direction: ParameterDirection.Output);

                cn.Execute("MAE.USP_REGISTRAR_UM", p, commandType: CommandType.StoredProcedure, commandTimeout: DbConfig.CommandTimeoutSeconds);
                return p.Get<int>("@NewID");
            }
        }

        public bool Actualizar(EUnidadMedida entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.MAE.UnidadMedida_Modificar,
                   new
                   {
                       entidad.UnidadMedidaId,
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

        public bool Eliminar(int id, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed()) 
            {
                var rows = cn.Execute(
                    SqlNames.MAE.UnidadMedida_Eliminar,
                    new { Id = id, User = user, Ip = ip },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }
    }
}
