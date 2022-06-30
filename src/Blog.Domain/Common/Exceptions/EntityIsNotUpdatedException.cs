namespace Blog.Domain.Common.Exceptions;

public class EntityIsNotUpdatedException : Exception
{
    public EntityIsNotUpdatedException() { }

    public EntityIsNotUpdatedException(string message) : base(message) { }
}