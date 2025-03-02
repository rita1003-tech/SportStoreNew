using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
