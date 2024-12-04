using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalService.DTOs
{
    public class WeatherDto
    {
        public string City { get; set; }
        public string WeatherDescription { get; set; }
        public double Temperature { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public string ErrorMessage { get; set; }
    }
}
