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
    public class PersonaService : IPersona
    { 
        private readonly IPersonaRepository _repo;

        public PersonaService(IPersonaRepository repo)
        {
            _repo = repo;
        }
        public Result Actualizar(EPersona entidad, string user, string ip)
        {
            Guard.POSTIVO(entidad.PersonaId, "ID Invalido");
            ValidarPersona(entidad, isUpdate:true);
            var OK = _repo.ActualizarPersona(entidad, user, ip);
            return OK ? Result.Success("Persona Actualizada")
                      : Result.Failure("Error al actualizar Persona");
        }
        public Result Eliminar(int id, string user, string ip)
        {
            Guard.POSTIVO(id, "ID Invalido"); 
            var OK = _repo.EliminarPersona(id, user, ip);
            return OK ? Result.Success("Persona Eliminada")
                      : Result.Failure("Error al eliminar Persona");
        }
        public Result<IEnumerable<EPersona>> Listar()
        {
            var data = _repo.ListarPersonas() ?? Enumerable.Empty<EPersona>();
            return Result<IEnumerable<EPersona>>.Success(data);
        }
        public Result<EPersona> Obtener(int id)
        {
            Guard.POSTIVO(id, "ID Invalido");
            var e = _repo.ObtenerPersona(id);
            return e == null ? Result<EPersona>.Failure("Persona no encontrado")
                             : Result<EPersona>.Success(e);
        }
        private static void ValidarPersona(EPersona e, bool isUpdate)
        {
            Guard.NOTNULL(e, "Entidad Requerida");
            Guard.NOTEMPTY(e.Documento, "Documento Requerido");
            Guard.NOTEMPTY(e.Nombres, "Nombres Requerido");
            Guard.NOTEMPTY(e.Apellidos, "Apellidos Requerido");
            Guard.MAXLENGTH(e.Documento, 20, "Documento excede longitud permitida");
            Guard.MAXLENGTH(e.Nombres, 100, "Nombres excede longitud permitida");
            Guard.MAXLENGTH(e.Apellidos, 100, "Apellidos excede longitud permitida");

            if (isUpdate)
            {
                Guard.POSTIVO(e.PersonaId, "ID Invalido");
                if (e.RowVersion == null || e.RowVersion.Length == 0)
                    throw new ValidationException("RowVersion requerido para actualización");
            }

            var doc = (e.Documento ?? string.Empty).Trim().ToUpper();
             
            if (!System.Text.RegularExpressions.Regex.IsMatch(doc, @"^\d{8}$|^\d{11}$|^[A-Z0-9]+-\d+$"))
            {
                throw new ValidationException("Documento inválido. Permitidos: DNI (8 dígitos), RUC (11 dígitos) o Tipo-Número (ej: P-12345678).");
            }

            if (!string.IsNullOrEmpty(e.Email))
            {
                Guard.MAXLENGTH(e.Email, 100, "Email excede longitud permitida");
                try
                { 
                    var _ = new System.Net.Mail.MailAddress(e.Email);
                }
                catch
                {
                    throw new ValidationException("Email inválido");
                }
            }

            if (!string.IsNullOrEmpty(e.Telefono))
            {
                Guard.MAXLENGTH(e.Telefono, 15, "Telefono excede longitud permitida");
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.Telefono.Trim(), @"^[0-9+\s\-]{6,15}$"))
                    throw new ValidationException("Telefono inválido. Solo dígitos, +, espacios o guiones, entre 6 y 15 caracteres.");
            }

        }
        public Result<int> Registrar(EPersona entidad, string user, string ip)
        {
            ValidarPersona(entidad, isUpdate:false);
            var id = _repo.RegistrarPersona(entidad, user, ip);
            return Result<int>.Success(id, "Persona Registrada");
        }


    }
}
