namespace Blog.Domain.Common.Extensions;

public static class StringExtension
{
    public static Guid ToGuid(this string txt)
    {
        return string.IsNullOrEmpty(txt) ? Guid.Empty : Guid.Parse(txt);
    }
}