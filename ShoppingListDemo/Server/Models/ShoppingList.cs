#nullable disable

namespace ShoppingListDemo.Server.Models
{
    public class ShoppingList : BaseEntity
    {
        public string Name { get; set; }
        public List<ShoppingItem> Items { get; set; } = new();
    }
}
