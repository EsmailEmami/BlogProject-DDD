using Blog.Application.SignalR.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Blog.Application.SignalR;

public class TestHub : Hub<ITestHubPushMethods>
{
    public async Task SendMessage(Guid userId, string message)
    {
        await Clients.User(userId.ToString()).SendMessage(message);
    }
}