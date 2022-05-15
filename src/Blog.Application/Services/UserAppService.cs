using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;

    public UserAppService(IMapper mapper, IMediatorHandler bus)
    {
        _mapper = mapper;
        _bus = bus;
    }


    public async Task<User?> GetUserByEmailAsync(string email)
    {
        GetUserByEmailQuery query = new GetUserByEmailQuery(email);

        try
        {
            return await _bus.SendQuery<GetUserByEmailQuery, User>(query);
        }
        catch
        {
            return null;
        }
    }

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

    public async Task<DashboardViewModel?> GetUserDashboardAsync(Guid userId)
    {
        GetUserDashboardQuery query = new GetUserDashboardQuery(userId);

        try
        {
            return await _bus.SendQuery<GetUserDashboardQuery, DashboardViewModel>(query);
        }
        catch
        {
            return null;
        }
    }

    public void Dispose() => GC.SuppressFinalize(this);
}