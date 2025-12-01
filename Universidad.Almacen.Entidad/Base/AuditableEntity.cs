using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Entidad.Base
{
    public abstract class AuditableEntity<Tkey> : EntityBase<Tkey>
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = "";
        public string CreatedFromIP { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFromIP { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
