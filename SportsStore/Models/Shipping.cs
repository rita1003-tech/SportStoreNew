using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{
    public class Shipping
    {
        public int ShippingId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier {  get; set; }
        public DateTime EstimatedDelivery {  get; set; }
        public string Status { get; set; }
    }
}
