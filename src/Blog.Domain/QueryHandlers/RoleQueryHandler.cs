using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.Role;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class RoleQueryHandler : QueryHandler,
    IRequestHandler<GetAllRolesQuery, List<Role>>
{
    private readonly IRoleRepository _roleRepository;
    public RoleQueryHandler(IMediatorHandler bus, IRoleRepository roleRepository) : base(bus)
    {
        _roleRepository = roleRepository;
    }

    public Task<List<Role>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_roleRepository.GetAll());
    }
}