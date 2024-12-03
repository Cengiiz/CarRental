using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarRentalMVC.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly RestClient _client;

        public UserRoleService(RestClient client)
        {
            _client = client;
        }

        public async Task<UserRoleDto> GetUserRoleAsync(int id)
        {
            var request = new RestRequest($"UserRoleApi/{id}", Method.Get);
            var response = await _client.ExecuteAsync<UserRoleDto>(request);
            return response.Data;
        }

        public async Task<List<UserRoleDto>> GetUserRolesAsync()
        {
            var request = new RestRequest("UserRoleApi", Method.Get);
            var response = await _client.ExecuteAsync<List<UserRoleDto>>(request);
            return response.Data;
        }

        public async Task<RestResponse> UpdateUserRoleAsync(UserRoleDto userDto)
        {
            
            var request = new RestRequest($"UserRoleApi/{userDto.Id}", Method.Put);

            
            var jsonBody = JsonSerializer.Serialize(userDto);
            request.AddJsonBody(jsonBody); // JSON gövdesini isteğe ekle

            
            var response = await _client.ExecuteAsync<RestResponse>(request);

            return response;
        }

    }
}
