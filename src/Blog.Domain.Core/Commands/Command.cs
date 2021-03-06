using Blog.Domain.Core.Events;
using FluentValidation.Results;

namespace Blog.Domain.Core.Commands;

public abstract class Command<TResult> : Message<TResult>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public abstract bool IsValid();
}