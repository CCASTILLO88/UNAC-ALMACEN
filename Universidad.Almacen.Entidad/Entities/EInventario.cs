using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Universidad.Almacen.Entidad.Base;

namespace Universidad.Almacen.Entidad.Entities
{
    public class EInventario : AuditableEntity<int>
    {
        public int InventarioId { get { return Id; } set { Id = value; } }
        public int AlmacenId { get; set; }
        public byte Tipo { get; set; }            // 1:Cíclico, 2:General
        public DateTime FechaProgramada { get; set; }
        public byte Estado { get; set; } = 1;     // 1:Abierto,2:Conteo,3:Cerrado
    }
}
