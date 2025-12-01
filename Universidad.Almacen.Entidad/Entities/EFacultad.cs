using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EFacultad : AuditableEntity<int>
    {
        public int FacultadID { get { return Id; } set { Id = value; } }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int SedeId { get; set; }
        public bool Activo { get; set; } = true;
    }
}
