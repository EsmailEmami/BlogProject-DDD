using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.User;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class UserQueryHandler : QueryHandler,
    IRequestHandler<IsUserExistsQuery, bool>,
    IRequestHandler<GetUserByEmailQuery, User>,
    IRequestHandler<GetUserDashboardQuery, DashboardViewModel>
{
    private readonly IUserRepository _userRepository;
    public UserQueryHandler(IMediatorHandler bus, IUserRepository userRepository) : base(bus)
    {
        _userRepository = userRepository;
    }

    public Task<bool> Handle(IsUserExistsQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        string existedHashPassword = _userRepository.GetUserPasswordByEmail(request.Email);
        if (!string.IsNullOrEmpty(existedHashPassword) &&
            existedHashPassword != request.Password)
        {
            Bus.RaiseEvent(new DomainNotification("Password not match", "کاربری با مشخصات وارد شده یافت نشد"));
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }

    public Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        User user = _userRepository.GetById(request.UserId);

        if (user.Email != request.Email)
        {
            Bus.RaiseEvent(new DomainNotification("user not exists", "کاربر مورد نظر یافت نشد."));
        }

        return Task.FromResult(user);
    }

    public Task<DashboardViewModel> Handle(GetUserDashboardQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        DashboardViewModel userDashboard = _userRepository.GetUserDashboard(request.UserId);

        if (userDashboard == null)
        {
            Bus.RaiseEvent(new DomainNotification("user not exists", "کاربر مورد نظر یافت نشد."));
            throw new EntityNotFoundException();
        }

        return Task.FromResult(userDashboard);
    }
}