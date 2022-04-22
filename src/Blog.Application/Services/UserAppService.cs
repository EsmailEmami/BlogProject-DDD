using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.ViewModels.User;

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

    public List<User> GetAllUsers() =>
        _userRepository.GetAll();

    public User? GetUserByEmail(string email) =>
        _userRepository.GetUserByEmail(email);

    public void Update(UpdateUserViewModel user)
    {
        UpdateUserCommand updateCommand = _mapper.Map<UpdateUserCommand>(user);
        _bus.SendCommand<UpdateUserCommand, bool>(updateCommand);
    }

    public void Remove(Guid userId)
    {
        RemoveUserCommand removeCommand = new RemoveUserCommand(userId);
        _bus.SendCommand<RemoveUserCommand, bool>(removeCommand);
    }

    public DashboardViewModel GetUserDashboard(Guid userId) =>
        _userRepository.GetUserDashboard(userId);

    public void Dispose() => GC.SuppressFinalize(this);
}