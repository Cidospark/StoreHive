using System;

namespace StoreHive.API.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public string RecieptNumber { get; set; }
        public User Customer { get; set; }
        public int CustomerId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Units Measurement { get; set; }
        public Status Status { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}