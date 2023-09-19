using AutoMapper;
using Splitwise.Dto;
using Splitwise.Models;
using Splitwise.Repositories;
using Splitwise.Shared;

namespace Splitwise.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public ServiceResult<string> Create(UserPostDto userPostDto)
    {
        var user = _mapper.Map<User>(userPostDto);
        user.Id = Guid.NewGuid().ToString();
        _userRepository.CreateUser(user);
        return new ServiceResult<string>(user.Id);
    }

    public ServiceResult<UserGetDto> Get(string userId)
    {
        if (_userRepository.TryGetUserByUserId(userId, out User user))
        {
            var userDto = _mapper.Map<UserGetDto>(user);
            return new ServiceResult<UserGetDto>(userDto);
        }

        return new ServiceResult<UserGetDto>(new Error(Constants.UserNotFound));
    }
}