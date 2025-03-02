using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status {  get; set; }
        public decimal TotalAmount { get; set; }
    }
}
