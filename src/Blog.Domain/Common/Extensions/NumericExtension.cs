namespace Blog.Domain.Common.Extensions;

public static class NumbExtension
{
    public static string Split(this int value) => value.ToString("#,0");
}