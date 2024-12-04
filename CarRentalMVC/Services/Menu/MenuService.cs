using CarRentalService.DTOs;
using RestSharp;

namespace CarRentalMVC.Services.Menu
{
    public class MenuService : IMenuService
    {
        private readonly RestClient _client;

        public MenuService(RestClient client)
        {
            _client = client;
        }

        public async Task<List<MenuItemDto>> GetMenuItemsAsync()
        {
            var request = new RestRequest($"MenuItemApi", Method.Get);
            var response = await _client.ExecuteAsync<List<MenuItemDto>>(request);
            return response.Data;
        }
        public async Task<List<MenuItemDto>> GetUserMenuItemsAsync(int id)
        {
            var request = new RestRequest($"MenuItemApi/user={id}", Method.Get);
            var response = await _client.ExecuteAsync<List<MenuItemDto>>(request);
            return response.Data;
        }
    }
}
