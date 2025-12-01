using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universidad.Almacen.Entidad.Base
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
    }
}
