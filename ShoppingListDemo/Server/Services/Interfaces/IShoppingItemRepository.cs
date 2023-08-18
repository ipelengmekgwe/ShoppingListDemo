using ShoppingListDemo.Shared;

namespace ShoppingListDemo.Server.Services.Interfaces
{
    public interface IShoppingItemRepository
    {
        Task Create(ShoppingItemDto shoppingItemDto);
        Task Update(int id, ShoppingItemDto shoppingItemDto);
        Task Delete(int id);
        Task<ShoppingItemDto> Get(int id);
        Task<IEnumerable<ShoppingItemDto>> GetAll();

        Task DeleteImage(int id);
    }
}
