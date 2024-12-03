using CarRentalService.DTOs;
using RestSharp;
using System.Text.Json;

namespace CarRentalMVC.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly RestClient _client;

        public VehicleService(RestClient client)
        {
            _client = client;
        }

        public async Task<VehicleDto> GetVehicleAsync(int id)
        {
            var request = new RestRequest($"VehicleApi/{id}", Method.Get);
            var response = await _client.ExecuteAsync<VehicleDto>(request);
            return response.Data;
        }

        public async Task<List<VehicleDto>> GetVehiclesAsync()
        {
            var request = new RestRequest("VehicleApi", Method.Get);
            var response = await _client.ExecuteAsync<List<VehicleDto>>(request);
            return response.Data;
        }

        public async Task<RestResponse> UpdateVehicleAsync(VehicleDto userDto)
        {

            var request = new RestRequest($"VehicleApi/{userDto.Id}", Method.Put);


            var jsonBody = JsonSerializer.Serialize(userDto);
            request.AddJsonBody(jsonBody); // JSON gövdesini isteğe ekle


            var response = await _client.ExecuteAsync<RestResponse>(request);

            return response;
        }

    }
}
