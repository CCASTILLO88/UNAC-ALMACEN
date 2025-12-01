using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class ETransferencia : AuditableEntity<int>
    {
        public int TransferenciaId { get { return Id; } set { Id = value; } }
        public DateTime Fecha { get; set; }
        public int AlmacenOrigenId { get; set; }
        public int AlmacenDestinoId { get; set; }
        public byte Estado { get; set; } = 1;       // 1:Registrada,2:Despachada,3:Recibida,0:Anulada
        public string Observacion { get; set; }
        public List<ETransferenciaDetalle> Detalles { get; set; } = new List<ETransferenciaDetalle>();
    }
}
