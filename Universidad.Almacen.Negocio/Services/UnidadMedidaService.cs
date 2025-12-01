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
    public class UnidadMedidaService : IUnidadMedida
    {
        private readonly IUnidadMedidaRepository _repo;

        public UnidadMedidaService(IUnidadMedidaRepository repo)
        {
            _repo = repo;
        }

        public Result Actualizar(EUnidadMedida entidad, string user, string ip)
        {
            Guard.NOTNULL(entidad, "Entidad Requerida");
            Guard.POSTIVO(entidad.UnidadMedidaId, "ID Invalido");
            Guard.NOTEMPTY(entidad.Codigo, "Codigo Requerido");
            Guard.NOTEMPTY(entidad.Nombre, "Nombre Requerido");
            Guard.MAXLENGTH(entidad.Codigo, 10, "Codigo excede longitud permitida");
            Guard.MAXLENGTH(entidad.Nombre, 100, "Nombre excede longitud permitida");

            var OK = _repo.Actualizar(entidad, user, ip);
            return OK ? Result.Success("Actualizado") : Result.Failure("Error al actualizar");
        }

        public Result Eliminar(int id, string user, string ip)
        {
            Guard.POSTIVO(id, "ID Invalido");
            var OK = _repo.Eliminar(id, user, ip);
            return OK ? Result.Success("Eliminado") : Result.Failure("Error al eliminar");
        }

        public bool ExisteActiva(int id)
        {
            var e = _repo.Obtener(id);
            return e != null && e.Activo; 
        }

        public Result<IEnumerable<EUnidadMedida>> Listar() => Result<IEnumerable<EUnidadMedida>>.Success(_repo.Listar() ?? Enumerable.Empty<EUnidadMedida>());

        public Result<EUnidadMedida> Obtener(int id)
        {
            Guard.POSTIVO(id, "ID Invalido");
            var e = _repo.Obtener(id);
            return e == null ? Result<EUnidadMedida>.Failure("Unidad de Medida no encontrado") 
                             : Result<EUnidadMedida>.Success(e);
        }

        public Result<int> Registrar(EUnidadMedida entidad, string user, string ip)
        {
            Guard.NOTNULL(entidad, "Entidad Requerida");
            Guard.NOTEMPTY(entidad.Codigo, "Codigo Requerido");
            Guard.NOTEMPTY(entidad.Nombre, "Nombre Requerido");
            Guard.MAXLENGTH(entidad.Codigo, 10, "Codigo excede longitud permitida");
            Guard.MAXLENGTH(entidad.Nombre, 100, "Nombre excede longitud permitida");
            var ID = _repo.Registrar(entidad, user, ip);
            return Result<int>.Success(ID, "Registrado");
        }
    }
}
