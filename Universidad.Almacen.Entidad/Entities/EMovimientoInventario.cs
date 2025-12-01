using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;
using Universidad.Almacen.Entidad.Enums;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EMovimientoInventario : AuditableEntity<long>
    {
        public long KardexId { get { return Id; } set { Id = value; } }
        public DateTime Fecha { get; set; }
        public int AlmacenId { get; set; }
        public int ArticuloId { get; set; }
        public int? LoteId { get; set; }
        public TipoMovimiento Tipo { get; set; }      // Ingreso/Salida/Ajuste
        public string Documento { get; set; }
        public decimal CantidadIn { get; set; }
        public decimal CantidadOut { get; set; }
    }
}
