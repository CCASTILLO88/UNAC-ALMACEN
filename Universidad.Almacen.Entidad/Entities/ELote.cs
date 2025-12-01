using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class ELote : AuditableEntity<int>
    {
        public int LoteID { get { return Id; } set { Id = value; } }
        public int ArticuloId { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public DateTime? FechaVencimiento { get; set; }
    }
}
