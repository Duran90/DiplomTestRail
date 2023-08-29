namespace BusinessObject.Models;

public class UserModel
{
    public UserModel(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public string Username { get; }
    public string Password { get; }
}