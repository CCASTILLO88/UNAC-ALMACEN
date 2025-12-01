using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class ESalidaDetalle : AuditableEntity<int>
    {
        public int SalidaDetalleId { get { return Id; } set { Id = value; } }
        public int SalidaId { get; set; }
        public int ArticuloId { get; set; }
        public decimal Cantidad { get; set; }
        public int? LoteId { get; set; }
    }
}
