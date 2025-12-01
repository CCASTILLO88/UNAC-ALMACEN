using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class ERequerimientoDetalle : AuditableEntity<int>
    {
        public int RequerimientoDetalleId { get { return Id; } set { Id = value; } }
        public int RequerimientoId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Cantidad { get; set; }
    }
}
