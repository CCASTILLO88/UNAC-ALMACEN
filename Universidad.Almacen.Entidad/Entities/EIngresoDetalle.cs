using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EIngresoDetalle : AuditableEntity<int>
    {
        public int IngresoDetalleId { get { return Id; } set { Id = value; } }
        public int IngresoId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal CostoUnitario { get; set; }
        public int? LoteId { get; set; }
    }
}
