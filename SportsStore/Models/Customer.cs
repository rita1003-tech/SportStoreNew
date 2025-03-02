using System;

namespace SportsStore.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Phone {  get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
