namespace ShoppingListDemo.Client.Services.Interfaces
{
    public interface IShoppingItemService
    {
        Task DeleteShoppingItem(int id);
        Task DeleteItemImage(int id);
    }
}
