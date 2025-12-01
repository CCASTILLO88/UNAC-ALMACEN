using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EUsuarioRol : AuditableEntity<int>
    {
        public int UsuarioRolId { get { return Id; } set { Id = value; } }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
    }
}
