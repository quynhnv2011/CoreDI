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
        public readonly IRepository<User> _userRepo;
        #endregion

        #region Constructors 
        public UserService()
        {
            _userRepo = new EfRepository<User>();
        }
        public UserService(IRepository<User> userRepo)
        {
            this._userRepo = userRepo;
        }
        #endregion


        public void AddUser(User item, ref string err)
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

        public IQueryable<User> GetAllUser()
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

        public User GetUserById(int id)
        {
            try
            {
                return _userRepo.GetById(id);
            }catch(Exception ex)
            {
                throw;
            }
        }

        public bool LogIn(string userName, string passWord, ref User user)
        {
            user = new User
            {
                UserName = "quynhnv",
                PassWord = "12345",
                Id = 1
            };
            return true;
        }

        public void UpdateUser(User item, ref string err)
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
