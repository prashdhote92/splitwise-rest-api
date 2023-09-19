using Splitwise.Dto;
using Splitwise.Shared;

namespace Splitwise.Services;

public interface IUserService
{
    ServiceResult<string> Create(UserPostDto userPostDto);
    ServiceResult<UserGetDto> Get(string userId);
}