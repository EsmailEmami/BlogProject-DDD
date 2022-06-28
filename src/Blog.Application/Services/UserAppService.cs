using AutoMapper;
using Blog.Application.Generator;
using Blog.Application.Interfaces;
using Blog.Application.ViewModels;
using Blog.Application.ViewModels.User;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
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

    public void UpdateUserPassword(UpdateUserPasswordViewModel user)
    {
        UpdateUserPasswordCommand command = _mapper.Map<UpdateUserPasswordCommand>(user);
        _bus.SendCommand<UpdateUserPasswordCommand, bool>(command);
    }

    public async Task<FilterUsersViewModel> GetUsers(int pageId, int take, string? search)
    {
        GetUsersCountQuery usersCountQuery = new(search);
        int count = await _bus.SendQuery<GetUsersCountQuery, int>(usersCountQuery);

        int pagesCount = (int)Math.Ceiling(count / (double)take);
        BasePaging pager = Pager.Build(pagesCount, pageId, take);

        GetUsersQuery usersQuery = new(pager.SkipEntity, pager.TakeEntity, search);
        List<UserForShowViewModel> users = await _bus.SendQuery<GetUsersQuery, List<UserForShowViewModel>>(usersQuery);

        return new FilterUsersViewModel(search).SetUsers(users)
            .SetPaging(pager);
    }

    public async Task<FilterUsersViewModel> GetAdmins(int pageId, int take, string? search)
    {
        GetAdminsCountQuery adminsCountQuery = new(search);
        int count = await _bus.SendQuery<GetAdminsCountQuery, int>(adminsCountQuery);

        int pagesCount = (int)Math.Ceiling(count / (double)take);
        BasePaging pager = Pager.Build(pagesCount, pageId, take);

        GetAdminsQuery adminsQuery = new(pager.SkipEntity, pager.TakeEntity, search);
        List<UserForShowViewModel> users = await _bus.SendQuery<GetAdminsQuery, List<UserForShowViewModel>>(adminsQuery);

        return new FilterUsersViewModel(search).SetUsers(users)
            .SetPaging(pager);
    }

    public async Task<UpdateUserViewModel> GetUserForUpdateAsync(Guid userId)
    {
        GetUserForUpdateQuery query = new(userId);
        return await _bus.SendQuery<GetUserForUpdateQuery, UpdateUserViewModel>(query);
    }

    public void Dispose() => GC.SuppressFinalize(this);
}