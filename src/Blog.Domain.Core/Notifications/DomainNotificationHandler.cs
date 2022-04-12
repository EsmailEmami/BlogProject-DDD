﻿using MediatR;

namespace Blog.Domain.Core.Notifications;

public class DomainNotificationHandler : INotificationHandler<DomainNotification>
{
    private List<DomainNotification> _notifications;

    public DomainNotificationHandler() => _notifications = new List<DomainNotification>();

    public Task Handle(DomainNotification message, CancellationToken cancellationToken)
    {
        _notifications.Add(message);

        return Task.CompletedTask;
    }

    public virtual List<DomainNotification> GetNotifications() => _notifications;
    public virtual bool HasNotifications() => GetNotifications().Any();
    public void Dispose() => _notifications = new List<DomainNotification>();
}