using ShoppingListDemo.Client.Services.Interfaces;
using ShoppingListDemo.Shared;
using System.Net.Http.Json;

namespace ShoppingListDemo.Client.Services
{
    public class ShoppingItemService : IShoppingItemService
    {
        private readonly HttpClient _httpClient;

        public ShoppingItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteShoppingItem(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/shoppingitem/delete/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task DeleteItemImage(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/shoppingitem/deleteimage/{id}");

            if (!response.IsSuccessStatusCode)
            {
                var errorModel = await response.Content.ReadFromJsonAsync<ErrorResponse>();
                throw new Exception(errorModel.ErrorMessage);
            }
        }
    }
}
