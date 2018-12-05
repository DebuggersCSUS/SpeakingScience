using SpeakingScience.Users.Core.Interfaces;
using SpeakingScience.Users.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingScience.Users.Data
{
    public class EFUsersRepository : IUserRepository
    {

        public EFUsersRepository(UsersEntityDB context)
        {
            _context = context;
        }

        public Core.Models.User Login(string userName, string password, ref string errorMessage)
        {
            if (string.IsNullOrEmpty(userName))
            {
                errorMessage = USERNAME_EMPTY_ERROR_MESSAGE;
            }
            if (string.IsNullOrEmpty(password))
            {
                errorMessage = PASSWORD_EMPTY_ERROR_MESSAGE;
            }

            var user = (from u in _usersDB
                       where u.UserName == userName && u.Password == password
                       select new
                       {
                           u.Password,
                           u.Id,
                           u.Usertype,
                           u.UserName
                       }).ToList().FirstOrDefault();
            if (user != null)
            {
                return new Core.Models.User(user.Id, user.UserName, user.Password, (Core.Models.UserType)user.Usertype);
            }

            errorMessage = NO_USER_ERROR_MESSAGE;
            return null;
        }

        private UsersEntityDB _context;
        private DbSet<User> _usersDB => _context?.Users;
        private const string NO_USER_ERROR_MESSAGE = "User not found matching those credentials.";
        private const string USERNAME_EMPTY_ERROR_MESSAGE = "User name cannot be empty.";
        private const string PASSWORD_EMPTY_ERROR_MESSAGE = "Password cannot be empty.";
    }
}
