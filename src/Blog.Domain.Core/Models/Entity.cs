using Dapper.Contrib.Extensions;

namespace Blog.Domain.Core.Models;

public abstract class Entity
{
    [ExplicitKey]
    public Guid Id { get; protected set; }
    public bool IsDeleted { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (GetHashCode() != other.GetHashCode())
            return false;

        return Id == other.Id;
    }
    public static bool operator ==(Entity? first, Entity? second)
    {
        if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
            return true;

        if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            return false;

        return first.Equals(second);
    }
    public static bool operator !=(Entity? first, Entity? second) => !(first == second);
    public override int GetHashCode() => GetType().GetHashCode() * 365 + Id.GetHashCode();
}