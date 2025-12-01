using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EIngreso : AuditableEntity<int>
    {
        public int IngresoId { get { return Id; } set { Id = value; } }
        public DateTime Fecha { get; set; }
        public int? ProveedorId { get; set; }
        public int AlmacenId { get; set; }
        public string TipoDocumento { get; set; }
        public string Serie { get; set; }
        public string Numero { get; set; }
        public string Observacion { get; set; }
        public byte Estado { get; set; } = 1; // 1:Activo, 0:Anulado
        public List<EIngresoDetalle> Detalles { get; set; } = new List<EIngresoDetalle>();
    }
}
