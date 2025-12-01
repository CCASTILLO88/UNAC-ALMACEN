using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EUsuario : AuditableEntity<int>
    {
        public int UsuarioId { get { return Id; } set { Id = value; } }
        public int PersonaId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; }
        public byte[] HashPass { get; set; }   
        public bool Activo { get; set; } = true;

        public List<string> Roles { get; set; } = new List<string>();
    }
}
