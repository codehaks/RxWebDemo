using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RxWebDemo.Models;

namespace RxWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("api/check")]
        public async Task<IActionResult> Check(string url, [FromServices] IWebHostEnvironment env)
        {
            _logger.LogInformation(url);

          

            if (url.Contains("google")) 
            {
                await Task.Delay(10000);
            }

            return Ok();
        }

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
