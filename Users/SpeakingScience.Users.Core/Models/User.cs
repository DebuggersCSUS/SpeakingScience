using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingScience.Users.Core.Models
{
    public class User
    {
        public User(Guid id, string userName, string pass, UserType userType)
        {
            ID = id;
            UserName = userName;
            Password = pass;
            UserType = userType;
        }

        public string UserName { get; private set; }

        public string Password { get; private set; } //I know

        public Guid ID { get; private set; }

        public UserType UserType { get; private set; }

    }

    public enum UserType
    {
        Admin,
        Assistant,
        Student,
    }
}
