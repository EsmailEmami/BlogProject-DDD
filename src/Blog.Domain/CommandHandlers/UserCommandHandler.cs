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
    IRequestHandler<RegisterNewUserCommand, Guid>,
    IRequestHandler<UpdateUserCommand, bool>,
    IRequestHandler<RemoveUserCommand, bool>,
    IRequestHandler<UpdateUserPasswordCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public UserCommandHandler(
        IMediatorHandler bus,
        IUserRepository userRepository,
        IPasswordHasher passwordHasher) : base(bus)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public Task<Guid> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(Guid.Empty);
        }

        User user = new User(Guid.NewGuid(), request.FirstName, request.LastName, request.Email, _passwordHasher.Hash(request.Password));

        if (_userRepository.IsEmailExists(user.Email))
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "your entered email address has been taken."));
        }

        _userRepository.Add(user);

        Bus.RaiseEvent(new UserRegisteredEvent(user.Id, user.FirstName, user.LastName, user.Email));


        return Task.FromResult(user.Id);
    }

    public Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        User user = new User(request.Id, request.FirstName, request.LastName, request.Email, string.Empty);
        User? existingUser = _userRepository.GetById(request.Id);

        if (existingUser == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر یافت نشد."));
        }

        user.SetPassword(existingUser.Password);

        if (existingUser.Id != user.Id)
        {
            if (!existingUser.Equals(user))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر در سیستم موجود است."));
                return Task.FromResult(false);
            }
        }

        _userRepository.Update(user);

        return Task.FromResult(true);
    }

    public Task<bool> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        User? user = _userRepository.GetById(request.Id);

        if (user == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر یافت نشد."));
            return Task.FromResult(false);
        }

        _userRepository.Delete(user);

        return Task.FromResult(true);
    }

    public Task<bool> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        if (!request.IsValid())
        {
            NotifyValidationErrors(request);
            return Task.FromResult(false);
        }

        User? user = _userRepository.GetById(request.Id);

        if (user == null)
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "کاربر مورد نظر یافت نشد."));
            return Task.FromResult(false);
        }

        if (!_passwordHasher.Check(user.Password, request.CurrentPassword))
        {
            Bus.RaiseEvent(new DomainNotification(request.MessageType, "رمز فعلی شما اشتباه است."));
            return Task.FromResult(false);
        }

        user.SetPassword(_passwordHasher.Hash(request.Password));
        _userRepository.Update(user);

        return Task.FromResult(true);
    }
}