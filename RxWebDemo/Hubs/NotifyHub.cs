using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RxWebDemo.Hubs
{
    public class NotifyHub:Hub
    {
        public async Task SendUpdateUrl(int index,int size)
        {
            await Clients.All.SendAsync("UpdateUrl", index, size);
        }
    }
}
