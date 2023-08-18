#nullable disable

namespace ShoppingListDemo.Shared
{
    public class ShoppingListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ShoppingItemDto> Items { get; set; } = new();
    }
}
