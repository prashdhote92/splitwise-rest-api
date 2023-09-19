using Splitwise.Models;

namespace Splitwise.Repositories;

public interface IUserRepository
{
    void CreateUser(User user);
    bool TryGetUserByUserId(string userId, out User user);
}