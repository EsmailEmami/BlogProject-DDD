using Blog.Domain.Commands.Role;
using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class RoleCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewRoleCommand, Guid>,
    IRequestHandler<UpdateRoleCommand, Role>
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

    public Task<Role> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        Role role = new Role(request.RoleId, request.RoleName);
        Role? existedRole = _roleRepository.GetById(request.RoleId);

        if (existedRole == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "مقام مورد نظر یافت نشد"));
            throw new EntityNotFoundException();
        }

        if (existedRole.RoleName == role.RoleName)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "لطفا مقام را ویرایش کنید"));
            throw new EntityIsNotUpdatedException();
        }

        _roleRepository.Update(role);
        return Task.FromResult(role);
    }
}