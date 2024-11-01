
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly HttpClient _httpClient;
        
        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            string apiKey = "your_api_key";
            string city = "Toronto";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            var response = await _httpClient.GetStringAsync(url);
            var weatherData = JObject.Parse(response);
            
            ViewData["City"] = city;
            ViewData["Temperature"] = weatherData["main"]["temp"];
            ViewData["Description"] = weatherData["weather"][0]["description"];
            
            return View();
        }
    }
}
