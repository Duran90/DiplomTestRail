using BusinessObject.Models;
using Core.Configuration;

namespace BusinessObject.Builders;

public static class UserBuilder
{
    private static readonly Bogus.Faker Faker =  new ();

    public static UserModel GetTestRailUser()
    {
        return new UserModel(AppConfiguration.Browser.UserEmail, AppConfiguration.Browser.UserPassword);
    }

    public static UserModel GetTestRailFakeUser()
    {
        return new UserModel(Faker.Internet.Email(), Faker.Internet.Password());
    }
    
    public static UserModel GetTestRailEmptyUser()
    {
        return new UserModel("", "");
    }
}