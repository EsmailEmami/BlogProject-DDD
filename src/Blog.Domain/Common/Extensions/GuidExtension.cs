namespace Blog.Domain.Common.Extensions;

public static class GuidExtension
{
    public static Guid ToGuid(this string value)
    {
        return string.IsNullOrEmpty(value) ? Guid.Empty : Guid.Parse(value);
    }

    public static bool IsEmpty(this Guid value)
    {
        return value == Guid.Empty;
    }
}