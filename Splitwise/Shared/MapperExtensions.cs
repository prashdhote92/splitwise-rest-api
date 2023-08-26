using Splitwise.Dto;
using Splitwise.Services;

namespace Splitwise.Shared;

public static class MapperExtensions
{
    public static UserDto GetUserDto(this User user)
    {
        return new UserDto()
        {
            Email = user.Email,
            Mobile = user.Mobile,
            Name = user.Name,
            Id = user.Id
        };
    }
    
}