using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EArticulo : AuditableEntity<int>
    {
        public int ArticuloId { get { return Id; } set { Id = value; } }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public int UnidadMedidaId { get; set; }
        public bool ControlaLote { get; set; } = false;
        public bool Activo { get; set; } = true;
        public Decimal QtyMin { get; set; }
        public Decimal QtyMax { get; set; }
        public int StockAlerta { get; set; }
    }
}
