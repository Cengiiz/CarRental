using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services
{
    public class UserService : IUserService
    {
        private readonly RestClient _client;

        public UserService(RestClient client)
        {
            _client = client;
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var request = new RestRequest("UserApi", Method.Get);
            var response = await _client.ExecuteAsync<List<UserDto>>(request);
            return response.Data;
        }
    }
}
