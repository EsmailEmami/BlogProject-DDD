namespace Blog.Domain.Core.Models;

public abstract class ValueObject<T> where T : ValueObject<T>
{
    protected abstract bool EqualsCore(T other);
    public override bool Equals(object? obj)
    {
        var valueObject = obj as T;
        if (ReferenceEquals(valueObject, null))
            return false;

        return EqualsCore(valueObject);
    }

    protected abstract int GetHashCodeCore();

    public override int GetHashCode() => GetHashCodeCore();

    public static bool operator ==(ValueObject<T>? first, ValueObject<T>? second)
    {
        if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
            return true;

        if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            return false;

        return first.Equals(second);
    }

    public static bool operator !=(ValueObject<T> first, ValueObject<T> second)
    {
        return !(first == second);
    }
}