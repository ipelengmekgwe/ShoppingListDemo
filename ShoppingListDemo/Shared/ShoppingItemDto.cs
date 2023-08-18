#nullable disable

using System.ComponentModel.DataAnnotations;

namespace ShoppingListDemo.Shared
{
    public class ShoppingItemDto
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        [Required(ErrorMessage = "Please enter item name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; } = 1;
        public virtual ICollection<ItemImageDto> Images { get; set; }
        public bool MarkOff { get; set; }
        public List<ImageFile> ImageFiles { get; set; } = new();
    }
}
