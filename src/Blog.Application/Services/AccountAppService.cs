using AutoMapper;
using Blog.Application.Interfaces;
using Blog.Domain.Commands.User;
using Blog.Domain.Core.Bus;
using Blog.Domain.Queries.User;
using Blog.Domain.ViewModels.User;

namespace Blog.Application.Services;

public class AccountAppService : IAccountAppService
{
    private readonly IMapper _mapper;
    private readonly IMediatorHandler _bus;

    public AccountAppService(IMapper mapper, IMediatorHandler bus)
    {
        _mapper = mapper;
        _bus = bus;
    }

    public async Task<UserForShowViewModel> RegisterAsync(RegisterViewModel register)
    {
        RegisterNewUserCommand registerCommand = _mapper.Map<RegisterNewUserCommand>(register);
        try
        {
            return await _bus.SendCommand<RegisterNewUserCommand, UserForShowViewModel>(registerCommand);
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> LoginAsync(LoginViewModel login)
    {
        IsUserExistsQuery query = _mapper.Map<IsUserExistsQuery>(login);

        return await _bus.SendQuery<IsUserExistsQuery, bool>(query);
    }

    public void Dispose() => GC.SuppressFinalize(this);
}