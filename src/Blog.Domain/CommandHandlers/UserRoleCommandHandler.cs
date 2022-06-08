using System.Data.SqlClient;
using Blog.Domain.Commands.UserRole;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class UserRoleCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewUserRoleCommand, bool>
{
    private readonly IUserRoleRepository _userRoleRepository;
    public UserRoleCommandHandler(IMediatorHandler bus, IUserRoleRepository userRoleRepository) : base(bus)
    {
        _userRoleRepository = userRoleRepository;
    }

    public Task<bool> Handle(RegisterNewUserRoleCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        UserRole userRole = new UserRole(Guid.NewGuid(), request.UserId, request.RoleId);


        try
        {
            _userRoleRepository.Add(userRole);
        }
        catch (SqlException exception)
        {
            if (exception.Number == 547)
            {
                Bus.RaiseEvent(new DomainNotification("UserRole Insert Failed", "متاسفانه هنگام وارد کردن مقام کاربر به مشکلی غیر منتظره برخوردیم."));
            }

            throw;
        }

        return Task.FromResult(true);
    }
}