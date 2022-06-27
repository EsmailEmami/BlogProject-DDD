using Blog.Domain.Common.Exceptions;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Queries.User;
using Blog.Domain.Services.Hash;
using Blog.Domain.ViewModels.User;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public class UserQueryHandler : QueryHandler,
    IRequestHandler<IsUserExistsQuery, bool>,
    IRequestHandler<GetUserByEmailQuery, User>,
    IRequestHandler<GetUserDashboardQuery, DashboardViewModel>,
    IRequestHandler<GetUsersQuery, List<UserForShowViewModel>>,
    IRequestHandler<GetAdminsQuery, List<UserForShowViewModel>>,
    IRequestHandler<GetUsersCountQuery, int>,
    IRequestHandler<GetAdminsCountQuery, int>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserQueryHandler(IMediatorHandler bus, IUserRepository userRepository, IPasswordHasher passwordHasher) : base(bus)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public Task<bool> Handle(IsUserExistsQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        string existedHashPassword = _userRepository.GetUserPasswordByEmail(request.Email);
        if (string.IsNullOrEmpty(existedHashPassword))
        {
            Bus.RaiseEvent(new DomainNotification("Password not match", "کاربری با مشخصات وارد شده یافت نشد"));
            return Task.FromResult(false);
        }

        if (_passwordHasher.Check(existedHashPassword, request.Password))
            return Task.FromResult(true);


        Bus.RaiseEvent(new DomainNotification("Password not match", "کاربری با مشخصات وارد شده یافت نشد"));
        return Task.FromResult(false);
    }

    public Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        User user = _userRepository.GetUserByEmail(request.Email);

        if (user == null)
        {
            Bus.RaiseEvent(new DomainNotification("user not exists", "کاربر مورد نظر یافت نشد."));
            throw new EntityNotFoundException();
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

    public Task<List<UserForShowViewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<UserForShowViewModel> users = _userRepository.GetUsers(request.Skip, request.Take, request.Search);

        return Task.FromResult(users);
    }

    public Task<int> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_userRepository.GetUsersCount(request.Search));
    }

    public Task<int> Handle(GetAdminsCountQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_userRepository.GetAdminsCount(request.Search));
    }

    public Task<List<UserForShowViewModel>> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            throw new InvalidOperationException();
        }

        List<UserForShowViewModel> admins = _userRepository.GetAdmins(request.Skip, request.Take, request.Search);

        return Task.FromResult(admins);
    }
}