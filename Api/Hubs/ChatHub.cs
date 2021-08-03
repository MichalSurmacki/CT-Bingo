using System.Threading.Tasks;
using Api.Hubs.Clients;
using Application.Models;
using Microsoft.AspNetCore.SignalR;

namespace Api.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message) => await Clients.All.ReceiveMessage(message);

    }
}