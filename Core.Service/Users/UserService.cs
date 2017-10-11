using Core.Business;
using Core.Business.EF;
using Core.Business.Object;
using Core.DataAccess;
using Core.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Core.Service.Users
{
    public partial class UserService : IUserService
    {
        #region Fields     
        public readonly IRepository<CoreUser> _userRepo;
        #endregion

        #region Constructors        
        public UserService(IRepository<CoreUser> userRepo)
        {
            this._userRepo = userRepo;
        }
        #endregion


        public void AddUser(CoreUser item, ref string err)
        {
            try
            {
                _userRepo.Insert(item);
            }
            catch(Exception ex)
            {
                err = ex.ToString();
            }           
        }

        public IQueryable<CoreUser> GetAllUser()
        {
            try
            {
               
                var query = from f in _userRepo.Table
                            select f;
                return query;              
            }
            catch (Exception ex)
            {
                return null;
            }
           
        }

        public CoreUser GetUserById(int id)
        {
            try
            {
                return _userRepo.GetById(id);
            }catch(Exception ex)
            {
                throw;
            }
        }

        public bool LogIn(string userName, string passWord, ref CoreUser user)
        {
            user = new CoreUser
            {
                UserName = "quynhnv",
                Password = "12345",
                UserID = 1
            };
            return true;
        }

        public IQueryable<CoreUser> Search(string userName, string email, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            try
            {
                var query = _userRepo.Table;                
                if (!String.IsNullOrWhiteSpace(userName))
                    query = query.Where(c => c.UserName.Contains(userName));
                if (!String.IsNullOrWhiteSpace(email))
                    query = query.Where(c => c.Email.Contains(email));
                query = query.OrderBy(c => c.UserName);

                var listUser = query.Skip(pageIndex * pageSize).Take(pageSize);
                return listUser;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public void UpdateUser(CoreUser item, ref string err)
        {
            try
            {
                _userRepo.Update(item);
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                throw;
            }
        }
    }
}
