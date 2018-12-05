using SpeakingScience.Users.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingScience.Users.Core.Interfaces
{
    public interface IUserRepository
    {

        /// <summary>
        /// Gets the user by username and password.
        /// </summary>
        /// <param name="userName">User name of the user.</param>
        /// <param name="password">Password of the user.</param>
        /// <param name="errorMessage">Error message to use.</param>
        /// <returns>Returns null if bad login, or User data if correct login.</returns>
        User Login(string userName, string password, ref string errorMessage);

    }
}
