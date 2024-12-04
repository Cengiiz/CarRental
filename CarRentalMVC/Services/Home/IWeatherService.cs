using CarRentalService.DTOs;

namespace CarRentalMVC.Services
{
    public interface IWeatherService
    {
        Task<WeatherDto> GetWeatherAsync(string city);
    }
}
