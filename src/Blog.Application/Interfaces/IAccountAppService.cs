using Blog.Domain.ViewModels.User;

namespace Blog.Application.Interfaces;

public interface IAccountAppService : IDisposable
{
    void Register(RegisterViewModel register);
    Task<bool> LoginAsync(LoginViewModel login);
}