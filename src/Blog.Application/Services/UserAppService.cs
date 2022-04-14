using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.Interfaces;
using Blog.Application.ViewModels.User;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;

namespace Blog.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IMediatorHandler _bus;

    public UserAppService(IMapper mapper, IUserRepository userRepository, IMediatorHandler bus)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _bus = bus;
    }

    public IList<User> GetAllUsers() =>
        _userRepository.GetAll()
            .ProjectTo<User>(_mapper.ConfigurationProvider)
            .ToList();

    public void Register(UserViewModel user)
    {
        RegisterNewUserCommand registerCommand = _mapper.Map<RegisterNewUserCommand>(user);
        _bus.SendCommand(registerCommand);
    }

    public void Update(UserViewModel user)
    {
        UpdateUserCommand updateCommand = _mapper.Map<UpdateUserCommand>(user);
        _bus.SendCommand(updateCommand);
    }

    public void Remove(Guid userId)
    {
        RemoveUserCommand removeCommand = new RemoveUserCommand(userId);
        _bus.SendCommand(removeCommand);
    }

    public void Dispose() => GC.SuppressFinalize(this);
}