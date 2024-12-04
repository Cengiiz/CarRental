using CarRentalService.DTOs;
using RestSharp;
using System.Text.Json;

namespace CarRentalMVC.Services
{
    public class VehicleLogService : IVehicleLogService
    {
        private readonly RestClient _client;

        public VehicleLogService(RestClient client)
        {
            _client = client;
        }

        public async Task<VehicleLogDto> GetVehicleLogAsync(int id)
        {
            var request = new RestRequest($"VehicleLogApi/{id}", Method.Get);
            var response = await _client.ExecuteAsync<VehicleLogDto>(request);
            return response.Data;
        }

        public async Task<List<VehicleLogDto>> GetVehicleLogsAsync()
        {
            var request = new RestRequest("VehicleLogApi", Method.Get);
            var response = await _client.ExecuteAsync<List<VehicleLogDto>>(request);
            return response.Data;
        }

        public async Task<RestResponse> UpdateVehicleLogAsync(VehicleLogDto userDto)
        {

            var request = new RestRequest($"VehicleLogApi/{userDto.Id}", Method.Put);


            var jsonBody = JsonSerializer.Serialize(userDto);
            request.AddJsonBody(jsonBody); // JSON gövdesini isteğe ekle


            var response = await _client.ExecuteAsync<RestResponse>(request);

            return response;
        }
    }
}
