using CarRentalMVC.Services.Home;
using CarRentalService.DTOs;
using Newtonsoft.Json;

namespace CarRentalMVC.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "bb08eccbe555bdf79907e1f1919193ac"; 
        private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather"; 

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherDto> GetWeatherAsync(string city)
        {
            var requestUrl = $"{BaseUrl}?q={city}&appid={ApiKey}&units=metric";  

            try
            {
                var response = await _httpClient.GetStringAsync(requestUrl);
                var weatherData = JsonConvert.DeserializeObject<WeatherDto>(response); 

                return weatherData;
            }
            catch (HttpRequestException ex)
            {
                
                return new WeatherDto
                {
                    ErrorMessage = $"Error retrieving weather data: {ex.Message}"
                };
            }
        }
    }
}
