using Splitwise.Dto;
using Splitwise.Shared;

namespace Splitwise.Services;

public interface IUserService
{
    ServiceResult<int> Create(UserPostDto userPostDto);
    ServiceResult<UserGetDto> Get(int userId);
}