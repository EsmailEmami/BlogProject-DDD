﻿using Blog.Application.Interfaces;
using Blog.Domain.Commands.UserRole;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.UserRole;

namespace Blog.Application.Services;

public class UserRoleAppService : IUserRoleAppService
{
    private readonly IMediatorHandler _bus;

    public UserRoleAppService(IMediatorHandler bus)
    {
        _bus = bus;
    }

    public async Task<bool> AddUserRoleAsync(Guid userId, Guid roleId)
    {
        RegisterNewUserRoleCommand command = new RegisterNewUserRoleCommand(userId, roleId);

        try
        {
            return await _bus.SendCommand<RegisterNewUserRoleCommand, bool>(command);
        }
        catch
        {
            return false;
        }
    }

    public async Task<List<Guid>> GetAllUserRolesIdAsync(Guid userId)
    {
        GetAllUserRolesIdQuery query = new GetAllUserRolesIdQuery(userId);

        try
        {
            return await _bus.SendQuery<GetAllUserRolesIdQuery, List<Guid>>(query);
        }
        catch
        {
            return new List<Guid>();
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}