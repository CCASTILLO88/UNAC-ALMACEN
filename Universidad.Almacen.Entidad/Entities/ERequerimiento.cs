using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;
using Universidad.Almacen.Entidad.Enums;

namespace Universidad.Almacen.Entidad.Entities
{
    public class ERequerimiento : AuditableEntity<int>
    {
        public int RequerimientoId { get { return Id; } set { Id = value; } }
        public byte Tipo { get; set; }                   // 1:Entrada, 2:Salida
        public DateTime Fecha { get; set; }
        public int SedeId { get; set; }
        public int? UnidadOrganicaId { get; set; }
        public int? SolicitanteId { get; set; }
        public EstadoRequerimiento Estado { get; set; } = EstadoRequerimiento.Borrador;
        public string Observacion { get; set; }
        public List<ERequerimientoDetalle> Detalles { get; set; } = new List<ERequerimientoDetalle>();
    }
}
