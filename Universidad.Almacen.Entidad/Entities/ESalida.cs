using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class ESalida : AuditableEntity<int>
    {
        public int SalidaId { get { return Id; } set { Id = value; } }
        public DateTime Fecha { get; set; }
        public int AlmacenId { get; set; }
        public int? DestinoUbicacionId { get; set; }
        public int? DestinoPersonaId { get; set; }
        public string Motivo { get; set; }
        public byte Estado { get; set; } = 1; // 1:Activo, 0:Anulado
        public List<ETransferenciaDetalle> Detalles { get; set; } = new List<ETransferenciaDetalle>();
    }
}
