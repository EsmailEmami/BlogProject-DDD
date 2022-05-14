using Blog.Domain.Core.Events;
using FluentValidation.Results;

namespace Blog.Domain.Core.Query;

public abstract class Query<TResult> : Message<TResult>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; }

    protected Query()
    {
        Timestamp = DateTime.Now;
    }

    public abstract bool IsValid();
}