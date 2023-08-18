#nullable disable
using ShoppingListDemo.Client.Services.Interfaces;
using ShoppingListDemo.Shared;
using System.Net.Http.Json;

namespace ShoppingListDemo.Client.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly HttpClient _httpClient;

        public ShoppingListService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ShoppingListDto>> GetShoppingLists()
        {
            var shoppingLists = await _httpClient.GetFromJsonAsync<IEnumerable<ShoppingListDto>>("api/shoppinglist");
            return shoppingLists;
        }

        public async Task<ShoppingListDto> GetShoppingListById(int id)
        {
            var response = await _httpClient.GetAsync($"api/shoppinglist/{id}");
            if (response.IsSuccessStatusCode)
            {
                var shoppingList = await response.Content.ReadFromJsonAsync<ShoppingListDto>();
                return shoppingList;
            }
            else
            {
                var errorModel = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task AddShoppingList(ShoppingListDto shoppingListDto)
        {
            await _httpClient.PostAsJsonAsync("api/shoppinglist/create", shoppingListDto);
        }

        public async Task UpdateShoppingList(int id, ShoppingListDto shoppingListDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/shoppinglist/update/{id}", shoppingListDto);

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task DeleteShoppingList(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/shoppinglist/delete/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
