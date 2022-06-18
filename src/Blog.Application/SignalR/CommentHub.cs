using Microsoft.AspNetCore.SignalR;

namespace Blog.Application.SignalR;

public class CommentHub : Hub
{
    private static readonly Dictionary<Guid, List<string>> Rooms = new();

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        string connectionId = Context.ConnectionId;

        List<string> activeRooms = new();

        foreach (Guid roomKey in Rooms.Keys)
        {
            bool result = Rooms[roomKey].Any(c => c == connectionId);

            if (result)
            {
                activeRooms.Add(roomKey.ToString());

                Rooms[roomKey].Remove(connectionId);
            }
        }

        foreach (string activeRoom in activeRooms)
        {
            await Groups.RemoveFromGroupAsync(connectionId, activeRoom);
        }
    }


    public async Task SetActiveBlogRoom(Guid blogId)
    {
        string connectionId = Context.ConnectionId;


        if (Rooms.TryGetValue(blogId, out List<string>? connections))
        {
            if (connections.All(c => c != connectionId))
            {
                Rooms[blogId].Add(connectionId);
            }
        }
        else
        {
            Rooms.Add(blogId, new List<string> { connectionId });
        }

        await Groups.AddToGroupAsync(connectionId, blogId.ToString());
    }
}
