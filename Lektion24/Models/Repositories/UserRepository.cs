using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Lektion24.Models.Entities;
using Lektion24.Models.Repositories.Abstract;
using Lektion24.Models.Repositories;

namespace Lektion24.Models.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserNameByEmail(string email);
        void RegisterUser(User user);
        void DeleteUserByUserName(string username);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository() : base() {}

        public User GetUserNameByEmail(string email)
        {
            return FindAll(u => u.Email == email).FirstOrDefault();
        }
        public void RegisterUser(User user)
        {
            user.ID = Guid.NewGuid();
            Save(user);
        }
        public void DeleteUserByUserName(string username)
        {
            var user = FindAll(u => u.UserName == username).FirstOrDefault();
            Delete(user);
        }
    }
}