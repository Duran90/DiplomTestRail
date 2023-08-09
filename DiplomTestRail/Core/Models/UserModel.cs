namespace DiplomTestRail.Core.Models;

public class UserModel
{
   
        public string? Email { get; set; }
        public string? Password { get; set; }

        public override string? ToString()
        {
            return $"Email: {Email} Password:{Password}";
        } 
}
