using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EPersona : AuditableEntity<int>
    {
        public int PersonaId { get { return Id; } set { Id = value; } }
        public string Documento { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; } = true;
    }
}
