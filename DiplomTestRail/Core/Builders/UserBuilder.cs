using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomTestRail.Core.Models
{
    public class UserBuilder
    {
        static Bogus.Faker _faker = new();

        public static UserModel GetTestRailUser()
        {
            return new UserModel 
            {
                Email = TestContext.Parameters.Get("Email"),
                Password =  TestContext.Parameters.Get("Password")
            };
        }
        
        public static UserModel GetTestRailFakeUser()
        {
            return new UserModel
            {
                Email = _faker.Internet.Email(),
                Password =  _faker.Internet.Password()
            };
        }
    }
}