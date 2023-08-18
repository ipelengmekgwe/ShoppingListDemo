#nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListDemo.Server.Models
{
    public class ItemImage : BaseEntity
    {
        public int ShoppingItemId { get; set; }
        public string ContentType { get; set; }
        [Column(TypeName = "image")]
        public byte[] ImageData { get; set; }
    }
}
