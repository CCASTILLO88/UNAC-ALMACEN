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
    //FALTAN CREAR TODOS LOS SP EN EL SQL PARA ESTE REPOSITORIO
    public class AlmacenVirtualRepository : IAlmacenVirtualRepository
    {
        public bool ActualizarAlmacenVirtual(EAlmacenVirtual entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.ALM.AlmacenVirtual_Modificar,
                    new
                    {
                        entidad.AlmacenVirtualID,
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

        public bool EliminarAlmacenVirtual(int id, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.ALM.AlmacenVirtual_Eliminar,
                    new
                    {
                        AlmacenVirtualID = id,
                        User = user,
                        IP = ip
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public IEnumerable<EAlmacenVirtual> ListarAlmacenVirtual()
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var lista = cn.Query<EAlmacenVirtual>(SqlNames.ALM.AlmacenVirtual_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return lista;
            }
        }

        public EAlmacenVirtual ObtenerAlmacenVirtual(int id)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var entidad = cn.QueryFirstOrDefault<EAlmacenVirtual>(SqlNames.ALM.AlmacenVirtual_Obtener,
                    new
                    {
                        AlmacenVirtualID = id
                    },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return entidad;
            }
        }

        public int RegistrarAlmacenVirtual(EAlmacenVirtual entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var p = new DynamicParameters();
                p.Add("@Codigo", entidad.Codigo);
                p.Add("@Nombre", entidad.Nombre);
                p.Add("@SedeId", entidad.SedeId);
                p.Add("@Activo", entidad.Activo);
                p.Add("@User", user);
                p.Add("@Ip", ip);
                p.Add("@NewID", dbType: DbType.Int64, direction: ParameterDirection.Output);
                cn.Execute(SqlNames.ALM.AlmacenVirtual_Registrar, p,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return p.Get<int>("@NewID");
            }

            /*
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
             */
        }
    }
}
