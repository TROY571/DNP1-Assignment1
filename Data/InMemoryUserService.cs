using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1two.Data
{
    public class InMemoryUserService:IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    Username = "siyu",
                    Password = "12345",
                    Age = 21,
                    SecurityLevel = 5
                },
                new User
                {
                    Username = "baby",
                    Password = "67890",
                    Age = 1,
                    SecurityLevel = 2
                }
            }.ToList();
        }
        public User ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}