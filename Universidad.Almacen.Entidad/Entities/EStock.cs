using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EStock : AuditableEntity<int>
    {
        public int StockId { get { return Id; } set { Id = value; } }
        public int AlmacenId { get; set; }
        public int ArticuloId { get; set; }
        public int? LoteId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Reservado { get; set; }
    }
}
