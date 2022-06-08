using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Queries.UserRole;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class UserRoleQueryHandler : QueryHandler,
    IRequestHandler<GetAllUserRolesIdQuery, List<Guid>>
{
    private readonly IUserRoleRepository _userRoleRepository;
    public UserRoleQueryHandler(IMediatorHandler bus, IUserRoleRepository userRoleRepository) : base(bus)
    {
        _userRoleRepository = userRoleRepository;
    }
    public Task<List<Guid>> Handle(GetAllUserRolesIdQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<Guid>? userRolesId = _userRoleRepository.GetAllUserRolesId(request.UserId);

        if (userRolesId == null)
        {
            return Task.FromResult(new List<Guid>());
        }

        return Task.FromResult(userRolesId);
    }
}