namespace Blog.Application.SignalR.Interfaces;

public interface ITestHubPushMethods
{
    Task SendMessage(string message);
}