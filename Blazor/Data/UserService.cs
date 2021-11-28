using System;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.Data
{
    public class UserServiceInMemory : IUserService
    {
        private readonly List<User> users;

        public UserServiceInMemory()
        {
            users = new[]
            {
                new User
                {
                    UserName = "admin",
                    Password = "admin",
                    Role = "ADMIN"
                },
                new User()
                {
                    UserName = "Anca",
                    Password = "000000",
                    Role = "MEMBER"
                }
            }.ToList();
        }

        public User ValidateUser(string UserName, string Password)
        {
            var temp = users.FirstOrDefault(user => user.UserName.Equals(UserName));
            if (temp == null) throw new Exception("User not found");

            if (!temp.Password.Equals(Password)) throw new Exception("Incorrect password");

            return temp;
        }
    }
}