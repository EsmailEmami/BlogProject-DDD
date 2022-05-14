using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.Core.Bus;
using Blog.Domain.Core.Commands;
using Blog.Domain.Core.Notifications;
using Blog.Domain.Core.Query;
using MediatR;

namespace Blog.Domain.QueryHandlers;

public abstract class QueryHandler
{
    protected readonly IMediatorHandler Bus;

    protected QueryHandler(IMediatorHandler bus)
    {
        Bus = bus;
    }
    protected void NotifyValidationErrors<TQuery>(Query<TQuery> message)
    {
        foreach (var error in message.ValidationResult.Errors)
        {
            Bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
        }
    }
}
