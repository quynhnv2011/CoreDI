using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
    public abstract partial class BaseEntity 
    {
        public int Id { get; set; }
        public virtual int CreatedBy { get;  set; }
        public virtual DateTime CreatedDate { get;  set; }
        public virtual int ChangedBy { get;  set; }
        public virtual DateTime ChangedDate { get;  set; }
    }
}
