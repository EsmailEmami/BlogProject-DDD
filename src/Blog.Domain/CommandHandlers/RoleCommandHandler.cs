using Blog.Domain.Commands.Role;
using Blog.Domain.Core.Bus;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class RoleCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewRoleCommand, Guid>
{
    private readonly IRoleRepository _roleRepository;
    public RoleCommandHandler(IMediatorHandler bus, IRoleRepository roleRepository) : base(bus)
    {
        _roleRepository = roleRepository;
    }


    public Task<Guid> Handle(RegisterNewRoleCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        Role role = new Role(Guid.NewGuid(), request.RoleName);
        _roleRepository.Add(role);

        return Task.FromResult(role.Id);
    }
}