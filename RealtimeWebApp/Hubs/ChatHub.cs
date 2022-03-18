using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace RealtimeWebApp.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(string user, string message);
    }

    [Authorize]
    public class ChatHub : Hub<IChatClient>
    {

        private readonly ILogger _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }

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

        public override async Task<Task> OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();

            if (httpContext == null)
                return base.OnConnectedAsync();

            int ideaId;
            try
            {
                ideaId = int.Parse(httpContext.Request.Query["ideaId"]);
            }
            catch (FormatException e)
            {
                throw new HubException("Invalid query param", e);
            }

            _logger.LogInformation(ideaId.ToString(), " Connected " + DateTime.Now);

            await SendMessageToCaller(ideaId.ToString(), " Connected " + DateTime.Now);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var httpContext = Context.GetHttpContext();

            if (httpContext == null)
                return base.OnConnectedAsync();

            int ideaId = int.Parse(httpContext.Request.Query["ideaId"]);

            _logger.LogInformation(ideaId.ToString()+ " Disconnected " + DateTime.Now);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
