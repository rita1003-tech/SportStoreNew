using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace SportsStore.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public string TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public Transaction Transaction { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
