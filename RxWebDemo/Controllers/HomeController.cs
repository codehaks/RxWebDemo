using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using RxWebDemo.Hubs;
using RxWebDemo.Models;

namespace RxWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<NotifyHub, INotifyHub> _notifyHub;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[Route("api/check")]
        //public async Task<IActionResult> Check(string url, [FromServices] IWebHostEnvironment env)
        //{
        //    _logger.LogInformation(url);

        //    var size = Observable.Return<long>(0);

        //    var b =  Subject.Create<long>();


        //    size.Select(async _ =>
        //    {
        //        var client = new HttpClient();
        //        var page = await client.GetAsync(url);
        //        var pageSize = page.Content.Headers.ContentLength.Value;
        //        return pageSize;
        //    }).Subscribe();           



        //    size.Subscribe(async _ =>
        //    {
        //        var client = new HttpClient();
        //        var page = await client.GetAsync(url);
        //        var pageSize = page.Content.Headers.ContentLength.Value;
        //        size.Next();
        //    },
        //    async () =>
        //    {
        //        await _notifyHub.Clients.All.SendUpdateUrl(0, 0);
        //    }
        //    );




        //    if (url.Contains("google"))
        //    {
        //        await Task.Delay(10000);
        //    }

        //    return Ok();
        //}

        //public static async IObservable<long> GetPageSize(string url)
        //{
        //    var client = new HttpClient();


        //    var page = await client.GetAsync(url);
        //    var pageSize = page.Content.Headers.ContentLength.Value;
        //    return Observable.Return<long>(pageSize);
        //    return Task.CompletedTask;
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
