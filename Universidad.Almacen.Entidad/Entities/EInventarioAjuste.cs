using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EInventarioAjuste : AuditableEntity<int>
    {
        public int InventarioAjusteId { get { return Id; } set { Id = value; } }
        public int InventarioId { get; set; }
        public int ArticuloId { get; set; }
        public int? LoteId { get; set; }
        public decimal CantidadAjuste { get; set; }   // +Ingreso / -Salida
        public string Motivo { get; set; }
    }
}
