#nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListDemo.Shared
{
    public class ItemImageDto
    {
        public int Id { get; set; }
        public int ShoppingItemId { get; set; }
        public string ContentType { get; set; }
        public byte[] ImageData { get; set; }
    }
}
