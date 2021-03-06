using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.Role;
using Blog.Domain.ViewModels.Role;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class RoleQueryHandler : QueryHandler,
    IRequestHandler<GetAllRolesQuery, List<Role>>,
    IRequestHandler<GetRoleForUpdateQuery, UpdateRoleViewModel>,
    IRequestHandler<GetRolesIdByNamesQuery, List<Guid>>
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

    public Task<UpdateRoleViewModel> Handle(GetRoleForUpdateQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        UpdateRoleViewModel? role = _roleRepository.GetRoleForUpdate(request.RoleId);

        if (role == null)
        {
            Bus.RaiseEvent(new DomainNotification("role not found", "مقام مورد نظر یافت نشد"));
            throw new EntityNotFoundException();
        }

        return Task.FromResult(role);
    }

    public Task<List<Guid>> Handle(GetRolesIdByNamesQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<Guid> roles;

        try
        {
            roles = _roleRepository.GetRolesIdByNames(request.Names);
        }
        catch
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "متاسفانه مشکلی پیش آمده است"));
            throw;
        }

        if (roles.Count != request.Names.Count)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "متاسفانه مشکلی پیش آمده است"));
            throw new InvalidOperationException();
        }


        return Task.FromResult(roles);
    }
}