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
    public class ProveedorRepository : IProveedorRepository
    {
        //FALTA SP EN SQL
        public bool ActualizarProveedor(EProveedor entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.MAE.Proveedor_Modificar,
                   new
                   {
                       entidad.ProveedorId,
                       entidad.Ruc,
                       entidad.RazonSocial,
                       entidad.Direccion,
                       entidad.Telefono,
                       entidad.Email,
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
        //FALTA SP EN SQL
        public bool EliminarProveedor(int id, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(
                    SqlNames.MAE.Proveedor_Eliminar,
                    new { Id = id, User = user, Ip = ip },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        //FALTA SP EN SQL
        public IEnumerable<EProveedor> ListarProveedores()
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var lista = cn.Query<EProveedor>(
                    SqlNames.MAE.Proveedor_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return lista;
            }
        }
        //FALTA SP EN SQL
        public EProveedor ObtenerProveedor(int id)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var entidad = cn.QueryFirstOrDefault<EProveedor>(
                    SqlNames.MAE.Proveedor_Obtener,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return entidad;
            }
        }

        //SI ESTA EL SP EN SQL
        public int RegistrarProveedor(EProveedor entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
               var parametros = new DynamicParameters();
                parametros.Add("Ruc", entidad.Ruc);
                parametros.Add("RazonSocial", entidad.RazonSocial);
                parametros.Add("Direccion", entidad.Direccion);
                parametros.Add("Telefono", entidad.Telefono);
                parametros.Add("Email", entidad.Email);
                parametros.Add("Activo", entidad.Activo);
                parametros.Add("User", user);
                parametros.Add("IP", ip);
                parametros.Add("NuevoId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                cn.Execute(SqlNames.MAE.Proveedor_Registrar,
                    parametros,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return parametros.Get<int>("NuevoId");
            }
        }
    }
}
