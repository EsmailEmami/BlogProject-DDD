namespace Blog.Domain.Interfaces;

public interface IUser
{
    public Guid UserId { get; }
    bool IsAuthenticated();
}