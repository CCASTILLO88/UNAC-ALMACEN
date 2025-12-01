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
    public class PersonaRepository : IPersonaRepository
    {
        public bool ActualizarPersona(EPersona entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.MAE.Persona_Modificar,
                   new
                   {
                       entidad.PersonaId,
                       entidad.Documento,
                       entidad.Nombres,
                       entidad.Apellidos,
                       entidad.Email,
                       entidad.Telefono,
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

        public bool EliminarPersona(int id, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(
                    SqlNames.MAE.Persona_Eliminar,
                    new { Id = id, User = user, Ip = ip },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
                return rows > 0;
            }
        }

        public IEnumerable<EPersona> ListarPersonas()
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                return cn.Query<EPersona>(
                    SqlNames.MAE.Persona_Listar,
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public EPersona ObtenerPersona(int id)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                return cn.QueryFirstOrDefault<EPersona>(
                    SqlNames.MAE.Persona_Obtener,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure,
                    commandTimeout: DbConfig.CommandTimeoutSeconds);
            }
        }

        public int RegistrarPersona(EPersona entidad, string user, string ip)
        {
            using (var cn = ConfigurationFactory.Create().OpenIfClosed()) 
            {
                var p = new DynamicParameters();
                p.Add("@Documento", entidad.Documento);
                p.Add("@Nombres", entidad.Nombres);
                p.Add("@Apellidos", entidad.Apellidos);
                p.Add("@Email", entidad.Email);
                p.Add("@Telefono", entidad.Telefono);
                p.Add("@Activo", entidad.Activo);
                p.Add("@User", user);
                p.Add("@Ip", ip);
                p.Add("@NewID", dbType:DbType.Int64, direction: ParameterDirection.Output);
                cn.Execute(SqlNames.MAE.Persona_Registrar, p, commandType: CommandType.StoredProcedure, commandTimeout: DbConfig.CommandTimeoutSeconds);
                return p.Get<int>("@NewID");
            }
        }
    }
}
