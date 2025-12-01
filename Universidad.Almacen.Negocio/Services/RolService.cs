using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Negocio.Common;
using Universidad.Almacen.Negocio.Interfaces;
using Universidad.Almacen.Entidad.Entities;
using Universidad.Almacen.Datos.Repositories.Interfaces;

namespace Universidad.Almacen.Negocio.Services
{
    public class RolService : IRol
    {
        private readonly IRolRepository _repo;
        public RolService(IRolRepository repo)
        {
            _repo = repo;
        }

        public Result Actualizar(ERol entidad, string user, string ip)
        {
            Guard.NOTNULL(entidad, "Entidad Requerida");
            Guard.POSTIVO(entidad.RolId, "ID Invalido");
            Guard.NOTEMPTY(entidad.Nombre, "Nombre Requerido");
            Guard.MAXLENGTH(entidad.Nombre, 50, "Nombre excede longitud permitida");    
            
            if (entidad.RowVersion == null || entidad.RowVersion.Length == 0)
                throw new ArgumentException("RowVersion requerida para actualizar");

            var ok =  _repo.ActualizarRol(entidad, user, ip);
            return ok ? Result.Success("Rol Actualizado")
                      : Result.Failure("Error al actualizar Rol");

        }

        public Result Eliminar(int id, string user, string ip)
        {
            Guard.POSTIVO(id, "ID Invalido");
            var ok =  _repo.EliminarRol(id, user, ip);
            return ok ? Result.Success("Rol Eliminado")
                      : Result.Failure("Error al eliminar Rol");
        }

        public Result<IEnumerable<ERol>> Listar()
        {
            return Result<IEnumerable<ERol>>.Success(_repo.ListarRoles() ?? Enumerable.Empty<ERol>());
        }

        public Result<ERol> Obtener(int id)
        {
            Guard.POSTIVO(id, "ID Invalido");
            var rol = _repo.ObtenerRol(id);
            return rol == null ? Result<ERol>.Failure("Rol no encontrado")
                              : Result<ERol>.Success(rol);
        }

        public Result<int> Registrar(ERol entidad, string user, string ip)
        {
            Guard.NOTNULL(entidad, "Entidad Requerida");
            Guard.POSTIVO(entidad.RolId, "ID Invalido");
            Guard.NOTEMPTY(entidad.Nombre, "Nombre Requerido");
            Guard.MAXLENGTH(entidad.Nombre, 50, "Nombre excede longitud permitida");    
            var id =  _repo.RegistrarRol(entidad, user, ip);
            return Result<int>.Success(id);
        }
    }
}
