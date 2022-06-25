using Blog.Domain.ViewModels.User;

namespace Blog.Application.Interfaces;

public interface IAccountAppService : IDisposable
{
    Task<UserForShowViewModel> RegisterAsync(RegisterViewModel register);
    Task<bool> LoginAsync(LoginViewModel login);
}