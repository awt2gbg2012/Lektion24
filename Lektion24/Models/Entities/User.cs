using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion24.Models.Entities.Abstract;

namespace Lektion24.Models.Entities
{
    public class User : IEntity
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public int Role { get; set; }

        public virtual ICollection<News> News { get; set; }
    }

    public enum UserRoles
    {
        User = 0,
        PowerUser = 1,
        Admin = 2,
        SuperUser = 3
    }
}