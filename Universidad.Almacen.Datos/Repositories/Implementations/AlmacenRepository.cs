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
    public class AlmacenRepository : IAlmacenRepository
    {
        public bool ActualizarAlmacen(EAlmacen entidad, string user, string ip)
        {
            using ( var cn = ConfigurationFactory.Create().OpenIfClosed())
            {
                var rows = cn.Execute(SqlNames.ALM.Almacen_Modificar,
                    new
                    {
                        entidad.AlmacenId,
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

        public bool EliminarAlmacen(int id, string user, string ip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EAlmacen> ListarAlmacenes()
        {
            throw new NotImplementedException();
        }

        public EAlmacen ObtenerAlmacen(int id)
        {
            throw new NotImplementedException();
        }

        public int RegistrarAlmacen(EAlmacen entidad, string user, string ip)
        {
            throw new NotImplementedException();
        }
    }
}
