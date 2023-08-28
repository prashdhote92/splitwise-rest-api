using Splitwise.Dto;
using Splitwise.Models;
using Splitwise.Shared;

namespace Splitwise.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public ServiceResult<int> Create(UserCreateDto userCreateDto)
    {
        var nextId = _userRepository.GetNextId();
        var user = userCreateDto.CreateUser(nextId);
        var newUserId = _userRepository.CreateUser(user);
        return newUserId > -1
            ? new ServiceResult<int>(newUserId)
            : new ServiceResult<int>(new Error(Constants.UserEmailAlreadyExists));
    }

    public ServiceResult<UserDto> Get(int userId)
    {
        if (_userRepository.TryGetUserByUserId(userId, out User user))
        {
            var userDto = user.CreateUserDto();
            return new ServiceResult<UserDto>(userDto);
        }

        return new ServiceResult<UserDto>(new Error(Constants.UserNotFound));
    }
}

//TODO to be replaced with postgres
/// <summary>
/// In memory DB for Users
/// </summary>
public interface IUserRepository
{
    int CreateUser(User user);
    bool TryGetUserByUserId(int userId, out User user);
    int GetNextId();
}

public class UserRepository : IUserRepository
{
    private SortedDictionary<int, User> _userTable;

    public UserRepository()
    {
        _userTable = new SortedDictionary<int, User>();
    }

    private bool IsUserEmailExists(string email)
    {
        return _userTable.Values.Any(x => x.Email == email);
    }

    public bool TryGetUserByUserId(int userId, out User user)
    {
        return _userTable.TryGetValue(userId, out user);
    }

    public int GetNextId()
    {
        return _userTable.Keys.LastOrDefault() + 1;
    }

    public int CreateUser(User user)
    {
        if (IsUserEmailExists(user.Email))
        {
            return -1;
        }

        _userTable.Add(user.Id, user);
        return user.Id;
    }
}