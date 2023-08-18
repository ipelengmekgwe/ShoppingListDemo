using ShoppingListDemo.Shared;

namespace ShoppingListDemo.Client.Services.Interfaces
{
    public interface IShoppingListService
    {
        Task<IEnumerable<ShoppingListDto>> GetShoppingLists();
        Task<ShoppingListDto> GetShoppingListById(int id);
        Task AddShoppingList(ShoppingListDto shoppingListDto);
        Task UpdateShoppingList(int id, ShoppingListDto shoppingListDto);
        Task DeleteShoppingList(int id);
    }
}
