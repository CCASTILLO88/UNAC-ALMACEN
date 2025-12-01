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
    public class CategoriaRepository : ICategoriaRepository
    {        
        public ECategoria ObtenerCategoria(int id)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                return cn.QueryFirstOrDefault<ECategoria>(
                    SqlNames.MAE.Categoria_Obtener,
                    new { CategoriaId = id },
                    commandType: System.Data.CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public int RegistrarCategoria(ECategoria entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var p = new DynamicParameters();
                p.Add("@Codigo", entidad.Codigo);
                p.Add("@Nombre", entidad.Nombre);
                p.Add("@Activo", entidad.Activo);
                p.Add("@User", user);
                p.Add("@Ip", ip);
                p.Add("@NewID", dbType: System.Data.DbType.Int64, direction: System.Data.ParameterDirection.Output);

                cn.Execute(SqlNames.MAE.Categoria_Registrar, p, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: DbConfig.CommandTimeoutSeconds);
                return p.Get<int>("@NewID");
            }
        }

        public bool ActualizarCategoria(ECategoria entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.MAE.Categoria_Modificar,
                   new
                   {
                       entidad.CategoriaId,
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

        public IEnumerable<ECategoria> ListarCategorias()
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                return cn.Query<ECategoria>(
                    SqlNames.MAE.Categoria_Listar,
                    commandType: System.Data.CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public bool EliminarCategoria(int id, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.MAE.Categoria_Eliminar,
                   new
                   {
                       CategoriaId = id,
                       User = user,
                       IP = ip
                   },
                   commandType: CommandType.StoredProcedure,
                   commandTimeout: DbConfig.CommandTimeoutSeconds);

                return rows > 0;
            }
        }
    }
}
