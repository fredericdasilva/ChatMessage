using ChatMessage.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Net;
using System.Threading.Tasks;

namespace ChatMessage.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MessageHub : Hub
    {

        
        public async Task NewMessage(Message msg)
        {
            var name = Context.User.Identity.Name;
            msg.username = name;

            await Clients.All.SendAsync("MessageReceived", msg);
        }

    }
}
