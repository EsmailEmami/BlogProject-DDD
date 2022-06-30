using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.Role;
using Blog.Domain.Core.Bus;
using Blog.Domain.Models;
using Blog.Domain.Queries.Role;
using Blog.Domain.ViewModels.Role;

namespace Blog.Application.Services;

public class RoleAppService : IRoleAppService
{
    private readonly IMediatorHandler _bus;
    private readonly IMapper _mapper;

    public RoleAppService(IMediatorHandler bus, IMapper mapper)
    {
        _bus = bus;
        _mapper = mapper;
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

    public async Task<UpdateRoleViewModel> GetRoleForUpdateAsync(Guid roleId)
    {
        GetRoleForUpdateQuery query = new(roleId);
        return await _bus.SendQuery<GetRoleForUpdateQuery, UpdateRoleViewModel>(query);
    }

    public async Task<Role> UpdateRoleAsync(UpdateRoleViewModel role)
    {
        UpdateRoleCommand command = _mapper.Map<UpdateRoleCommand>(role);
        return await _bus.SendCommand<UpdateRoleCommand, Role>(command);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}