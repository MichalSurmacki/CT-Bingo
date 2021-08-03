using System.Threading.Tasks;
using Application.Models;

namespace Api.Hubs.Clients
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}