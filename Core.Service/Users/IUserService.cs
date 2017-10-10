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
        bool LogIn(string userName, string passWord, ref User user);
        void AddUser(User item, ref string err);
        void UpdateUser(User item, ref string err);
        User GetUserById(int id);
        IQueryable<User> GetAllUser();
    }
}
