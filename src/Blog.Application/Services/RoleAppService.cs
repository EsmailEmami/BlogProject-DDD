using Blog.Application.Interfaces;
using Blog.Domain.Commands.Role;
using Blog.Domain.Core.Bus;
using Blog.Domain.Models;
using Blog.Domain.Queries.Role;

namespace Blog.Application.Services;

public class RoleAppService : IRoleAppService
{
    private readonly IMediatorHandler _bus;

    public RoleAppService(IMediatorHandler bus)
    {
        _bus = bus;
    }

    public async Task<Guid> AddRoleAsync(string roleName)
    {
        RegisterNewRoleCommand command = new RegisterNewRoleCommand(roleName);
        try
        {
            return await _bus.SendCommand<RegisterNewRoleCommand, Guid>(command);
        }
        catch
        {
            return Guid.Empty;
        }
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        GetAllRolesQuery query = new GetAllRolesQuery();
        return await _bus.SendQuery<GetAllRolesQuery, List<Role>>(query);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}