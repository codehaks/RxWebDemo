using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RxWebDemo.Hubs
{
    public class NotifyHub : Hub
    {
        public async Task UpdateUrl(int index, string url)
        {
            var client = new HttpClient();
            var page = await client.GetAsync(url);
            var pageSize = page.Content.Headers.ContentLength.Value;

            await Clients.All.SendAsync("updateUrl",index, pageSize);// ("UpdateUrl", index, size);
        }
    }
}
