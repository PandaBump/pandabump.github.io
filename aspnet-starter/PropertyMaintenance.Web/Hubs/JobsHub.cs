using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace PropertyMaintenance.Web.Hubs;

[Authorize(Roles = "Owner,Admin,Technician")]
public class JobsHub : Hub
{
    public async Task SubscribeAdminBoard()
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, "admins");
    }
}
