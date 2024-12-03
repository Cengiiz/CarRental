using CarRentalService.DTOs;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarRentalMVC.Services
{
    public class UserService : IUserService
    {
        private readonly RestClient _client;

        public UserService(RestClient client)
        {
            _client = client;
        }

        public async Task<UserDto> GetUserAsync(int id)
        {
            var request = new RestRequest($"UserApi/{id}", Method.Get);
            var response = await _client.ExecuteAsync<UserDto>(request);
            return response.Data;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var request = new RestRequest("UserApi", Method.Get);
            var response = await _client.ExecuteAsync<List<UserDto>>(request);
            return response.Data;
        }

        public async Task<RestResponse> UpdateUserAsync(UserDto userDto)
        {
            
            var request = new RestRequest($"UserApi/{userDto.Id}", Method.Put);

            
            var jsonBody = JsonSerializer.Serialize(userDto);
            request.AddJsonBody(jsonBody); // JSON gövdesini isteğe ekle

            
            var response = await _client.ExecuteAsync<RestResponse>(request);

            return response;
        }

        public async Task<RestResponse> ValidateUser(string userName, string pass)
        {

            var request = new RestRequest($"validate?username={userName}&password={pass}", Method.Get);
            var response = await _client.ExecuteAsync<RestResponse>(request);

            return response;
        }


    }
}
