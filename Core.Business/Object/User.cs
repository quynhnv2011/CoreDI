using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Object
{
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
