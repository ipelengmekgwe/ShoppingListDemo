#nullable disable

namespace ShoppingListDemo.Server.Models
{
    public class ShoppingItem : BaseEntity
    {
        public int ShoppingListId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set;}
        public List<ItemImage> Images { get; set; } = new();
        public bool MarkOff { get; set; }
    }
}
