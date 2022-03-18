using Microsoft.AspNetCore.SignalR;

namespace RealtimeWebApp.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
    }

    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage(user, message);
        }

        public Task SendMessageToCaller(string user, string message)
        {
            return Clients.Caller.ReceiveMessage(user, message);
        }

        public Task SendMessageToGroup(string user, string message)
        {
            return Clients.Group("SignalR Users").ReceiveMessage(user, message);
        }
    }
}
