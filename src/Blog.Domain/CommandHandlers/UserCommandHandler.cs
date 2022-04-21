using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Events.User;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using Blog.Domain.Services.Hash;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class UserCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewUserCommand, bool>,
    IRequestHandler<UpdateUserCommand, bool>,
    IRequestHandler<RemoveUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IMediatorHandler _bus;
    private readonly IPasswordHasher _passwordHasher;

    public UserCommandHandler(IUnitOfWork uow,
        IMediatorHandler bus,
        INotificationHandler<DomainNotification> notifications,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher) : base(uow, bus, notifications)
    {
        _bus = bus;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public Task<bool> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        User user = new User(Guid.NewGuid(), request.FirstName, request.LastName, request.Email, _passwordHasher.Hash(request.Password));

        if (_userRepository.IsEmailExists(user.Email))
        {
            _bus.RaiseEvent(new DomainNotification(request.MessageType, "your entered email address has been taken."));
        }

        _userRepository.Add(user);

        if (Commit())
        {
            _bus.RaiseEvent(new UserRegisteredEvent(user.Id, user.FirstName, user.LastName, user.Email));
        }

        return Task.FromResult(true);
    }

    public Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        User existingUser = _userRepository.GetById(request.Id);

        if (existingUser == null)
        {
            _bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر یافت نشد."));
            return Task.FromResult(false);
        }

        User user = new User(request.Id, request.FirstName, request.LastName, request.Email, existingUser.Password);

        _userRepository.Update(user);
        Commit();

        return Task.FromResult(true);
    }

    public Task<bool> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        User user = _userRepository.GetById(request.Id);

        if (user.Id != request.Id)
        {
            _bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر یافت نشد."));
        }

        _userRepository.Delete(user);

        Commit();

        return Task.FromResult(true);
    }
}