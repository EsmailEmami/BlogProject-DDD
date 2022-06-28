using Blog.Application.Interfaces;
using Blog.Domain.ViewModels.User;
using Microsoft.AspNetCore.SignalR;

namespace Blog.Application.SignalR;

public class UserManagerHub : Hub
{
    public Task AddNewAdmin(UserForShowViewModel user)
    {
        return Clients.All.SendAsync("ReceiveNewAdmin", user);
    }

    public Task RemoveUserFromAdmin(Guid userId, string fullName)
    {
        return Clients.All.SendAsync("ReceiveRemovedUserFromAdmin", userId, fullName);
    }
}