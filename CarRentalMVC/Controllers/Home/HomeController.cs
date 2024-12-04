using CarRentalMVC.Services;
using CarRentalMVC.Services.Home;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarRentalMVC.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;
        private readonly IExchangeRateService _exchangeRateService;
        private readonly INewsService _newsService;

        public HomeController(IWeatherService weatherService, IExchangeRateService exchangeRateService, INewsService newsService)
        {
            _weatherService = weatherService;
            _exchangeRateService = exchangeRateService;
            _newsService = newsService;
             
             
        }
        //private readonly HttpClient _httpClient;

        //public HomeController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        public async Task<IActionResult> Index()
        {
            //var weather = await _weatherService.GetWeather("Istanbul");
            //var exchangeRates = await _exchangeRateService.GetExchangeRates("USD");
            //var carRentalNews = await _newsService.GetCarRentalNews();

            var weather = await _weatherService.GetWeatherAsync("Istanbul");

            if (weather.ErrorMessage != null)
            {
                ViewBag.ErrorMessage = weather.ErrorMessage;
            }
            else
            {
                ViewBag.Weather = weather;
            }


            //var exchangeRateUrl = "https://api.exchangerate-api.com/v4/latest/USD";
            //var exchangeRateResponse = await _httpClient.GetStringAsync(exchangeRateUrl);
            //var exchangeRateData = JsonConvert.DeserializeObject<dynamic>(exchangeRateResponse);


            //var newsUrl = "https://newsapi.org/v2/everything?q=car%20rental&apiKey=your_api_key";
            //var newsResponse = await _httpClient.GetStringAsync(newsUrl);
            //var newsData = JsonConvert.DeserializeObject<dynamic>(newsResponse);


            //ViewBag.ExchangeRates = exchangeRateData;
            //ViewBag.News = newsData;

            return View();

        }
    }

}
