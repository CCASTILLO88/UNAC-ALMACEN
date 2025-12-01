using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class ETransferenciaDetalle : AuditableEntity<int>
    {
        public int TransferenciaDetalleId { get { return Id; } set { Id = value; } }
        public int TransferenciaId { get; set; }
        public int ArticuloId { get; set; }
        public int? LoteId { get; set; }
        public decimal Cantidad { get; set; }
    }
}
