using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public static class TaskExtensions
    {
        public async Task<T> UnwrapError<T>(this Task<T> task)
        {
            try
            {
                var result = await task;
            }
            catch (ApiException<ProblemDetails> ex)
            {
                
            }
        }
    }

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebApplication1Client _client;

        public HomeController(ILogger<HomeController> logger, WebApplication1Client client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _client.WeatherForecastAsync().UnwrapError();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}