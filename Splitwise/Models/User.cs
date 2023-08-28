namespace Splitwise.Models;

public class User
{
    public User(int userId, string email, string name, string mobile, string password)
    {
        Id = userId;
        Email = email;
        Name = name;
        Mobile = mobile;
        Password = password;
    }

    public int Id { get; }
    public string Email { get; }
    public string Name { get; }
    public string Password { get; }
    public string Mobile { get; }

    public DateTime CreatedAt { get; set; }
}