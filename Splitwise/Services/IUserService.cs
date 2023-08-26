using Splitwise.Dto;
using Splitwise.Shared;

namespace Splitwise.Services;

public interface IUserService
{
    ServiceResult<int> Create(UserCreateDto userCreateDto);
    ServiceResult<UserDto> Get(int userId);
}