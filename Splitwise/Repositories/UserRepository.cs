using Splitwise.Models;
using Splitwise.Shared;

namespace Splitwise.Repositories;

public class UserRepository : IUserRepository
{
    
    private readonly DataContext _dataContext;

    public UserRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void CreateUser(User user)
    {
        _dataContext.Users.Add(user);
        _dataContext.SaveChanges();
    }

    public bool TryGetUserByUserId(string userId, out User user)
    {
        user = _dataContext.Users.FirstOrDefault(x=>x.Id == userId);
        return user != null;
    }

}