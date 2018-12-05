using SpeakingScience.Users.Core.Interfaces;
using SpeakingScience.Users.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakingScience.Users.Data
{
    public class MockUsersRepository : IUserRepository
    {

        public MockUsersRepository()
        {
            Users = new List<Core.Models.User>()
            {
                new Core.Models.User(new Guid("ea2470a5-ac04-4e9c-bb29-91806692e068"), "Shadow", "password", Core.Models.UserType.Admin),
                new Core.Models.User(new Guid("3ed2fad6-282e-4604-ba9c-70685ec03434"), "Brandon", "password", Core.Models.UserType.Student),
                new Core.Models.User(new Guid("057e6779-2c10-4e49-8099-2476e0a11088"), "Cecilia", "password", Core.Models.UserType.Student),
                new Core.Models.User(new Guid("56b343b1-11f2-4839-919f-f610553eca70"), "G", "password", Core.Models.UserType.Student),
                new Core.Models.User(new Guid("9be04011-e322-487b-ac19-85dc9c135021"), "Autumn", "password", Core.Models.UserType.Assistant)
            };
        }

        public Core.Models.User Login(string userName, string password, ref string errorMessage)
        {
            return Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }

        public List<Core.Models.User> Users;

    }
}
