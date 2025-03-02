using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models {

    public class Product {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int Stock {  get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category category { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
