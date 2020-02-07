using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RxWebDemo.Hubs
{
    public class NotifyHub : Hub<INotifyHub>
    {
        public async Task UpdateUrl(int index, int size)
        {
            await Clients.All.SendUpdateUrl(index, size);// ("UpdateUrl", index, size);
        }
    }
}
