namespace Splitwise.Dto;

public class User
{
    public User(string email, string name, string mobile, string password)
    {
        Email = email;
        Name = name;
        Mobile = mobile;
        Password = password;
    }

    public int Id { get; set; }
    public string Email { get; }
    public string Name { get; }
    public string Password { get; }
    public string Mobile { get; }

    public DateTime CreatedAt { get; set; }
}