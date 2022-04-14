using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Events.User;
using Blog.Domain.Interfaces;
using Blog.Domain.Models;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class UserCommandHandler : CommandHandler,
    IRequestHandler<RegisterNewUserCommand, bool>,
    IRequestHandler<UpdateUserCommand, bool>,
    IRequestHandler<RemoveUserCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IMediatorHandler _bus;

    public UserCommandHandler(IUnitOfWork uow,
        IMediatorHandler bus,
        INotificationHandler<DomainNotification> notifications,
        IUserRepository userRepository) : base(uow, bus, notifications)
    {
        _bus = bus;
        _userRepository = userRepository;
    }

    public Task<bool> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        User user = new User(Guid.NewGuid(), request.FirstName, request.LastName, request.Email);

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

        User user = new User(request.Id, request.FirstName, request.LastName, request.Email);
        User existingUser = _userRepository.GetById(user.Id);

        if (existingUser.Id != user.Id)
        {
            if (!existingUser.Equals(user))
            {
                _bus.RaiseEvent(new DomainNotification(request.MessageType, "The user has already been taken."));
                return Task.FromResult(false);
            }
        }
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

        _userRepository.Remove(request.Id);
        Commit();

        return Task.FromResult(true);
    }
}