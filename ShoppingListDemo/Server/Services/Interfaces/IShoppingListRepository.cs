using ShoppingListDemo.Shared;

namespace ShoppingListDemo.Server.Services.Interfaces
{
    public interface IShoppingListRepository
    {
        Task Create(ShoppingListDto shoppingListDto);
        Task Update(int id, ShoppingListDto shoppingListDto);
        Task Delete(int id);
        Task<ShoppingListDto> Get(int id);
        Task<IEnumerable<ShoppingListDto>> GetAll();
    }
}
