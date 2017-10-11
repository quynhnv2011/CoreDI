using Core.Business.EF;
using Core.Business.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Users
{
    public partial interface IUserService
    {
        bool LogIn(string userName, string passWord, ref CoreUser user);
        void AddUser(CoreUser item, ref string err);
        void UpdateUser(CoreUser item, ref string err);
        CoreUser GetUserById(int id);
        IQueryable<CoreUser> GetAllUser();
        IQueryable<CoreUser> Search(string userName, string email, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
