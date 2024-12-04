using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarRentalMVC.Services
{
    public class RoleService : IRoleService
    {
        private readonly RestClient _client;

        public RoleService(RestClient client)
        {
            _client = client;
        }

        public async Task<RoleDto> GetRoleAsync(int id)
        {
            var request = new RestRequest($"RoleApi/{id}", Method.Get);
            var response = await _client.ExecuteAsync<RoleDto>(request);
            return response.Data;
        }

        public async Task<List<RoleDto>> GetRolesAsync()
        {
            var request = new RestRequest("RoleApi", Method.Get);
            var response = await _client.ExecuteAsync<List<RoleDto>>(request);
            return response.Data;
        }

        public async Task<RestResponse> UpdateRoleAsync(RoleDto roleDto)
        {
            
            var request = new RestRequest($"RoleApi/{roleDto.Id}", Method.Put);

            
            var jsonBody = JsonSerializer.Serialize(roleDto);
            request.AddJsonBody(jsonBody); // JSON gövdesini isteğe ekle

            
            var response = await _client.ExecuteAsync<RestResponse>(request);

            return response;
        }

        public async Task<RoleDto> ValidateRole(string userName, string pass)
        {

            var request = new RestRequest($"LoginApi/validate/username={userName}&password={pass}", Method.Get);
            var response = await _client.ExecuteAsync<RoleDto>(request);

            return response.Data;
        }


    }
}
