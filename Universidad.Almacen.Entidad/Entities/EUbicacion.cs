using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EUbicacion : AuditableEntity<int>
    {
        public int UbicacionId { get { return Id; } set { Id = value; } }
        public string Codigo { get; set; } = string.Empty;   // aula/oficina/lab
        public string Nombre { get; set; } = string.Empty;
        public int UnidadOrganicaId { get; set; }
        public bool Activo { get; set; } = true;
    }
}
