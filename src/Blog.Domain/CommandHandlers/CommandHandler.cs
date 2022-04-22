﻿using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Interfaces;
using MediatR;

namespace Blog.Domain.CommandHandlers;

public class CommandHandler
{
    private readonly IUnitOfWork _uow;
    private readonly IMediatorHandler _bus;
    private readonly DomainNotificationHandler _notifications;

    public CommandHandler(IUnitOfWork uow,
        IMediatorHandler bus,
        INotificationHandler<DomainNotification> notifications)
    {
        _uow = uow;
        _bus = bus;
        _notifications = (DomainNotificationHandler)notifications;
    }
    protected void NotifyValidationErrors<TCommand>(Command<TCommand> message)
    {
        foreach (var error in message.ValidationResult.Errors)
        {
            _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }
    }

    public bool Commit()
    {
        if (_notifications.HasNotifications()) return false;
        if (_uow.Commit()) return true;


        _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
        return false;
    }
}