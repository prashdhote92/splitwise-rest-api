using Splitwise.Dto;
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
        var newUserId = _userRepository.CreateUser(userCreateDto);
        return newUserId > -1
            ? new ServiceResult<int>(newUserId)
            : new ServiceResult<int>(new Error(Constants.UserEmailAlreadyExists));
    }

    public ServiceResult<UserDto> Get(int userId)
    {
        if (_userRepository.TryGetUserByUserId(userId, out User user))
        {
            var userDto = user.GetUserDto();
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
    int CreateUser(UserCreateDto user);
    bool TryGetUserByUserId(int userId, out User user);
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

    public int CreateUser(UserCreateDto userCreateDto)
    {
        if (IsUserEmailExists(userCreateDto.Email))
        {
            return -1;
        }

        var user = GetMappedUser(userCreateDto);
        _userTable.Add(user.Id, user);
        return user.Id;
    }

    private User GetMappedUser(UserCreateDto userCreateDto)
    {
        var userIds = _userTable.Keys;
        var maxUserId = userIds.Any() ? userIds.Last() : -1;
        var user = new User(userCreateDto.Email, userCreateDto.Name, userCreateDto.Mobile, userCreateDto.Password)
        {
            Id = maxUserId + 1,
            CreatedAt = DateTime.UtcNow
        };

        return user;
    }
}