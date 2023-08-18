#nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListDemo.Server.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; }
    }
}
