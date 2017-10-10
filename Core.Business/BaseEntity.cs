using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public abstract partial class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
