using System;
using System.Collections.Generic;

namespace StoreHive.API.Models
{
    public class Store
    {
        public int Id { get; set; }
        public User Owner { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool HasPermit { get; set; }
        public string ReferalLink { get; set; }
        public string Description { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set; }
        public ICollection<Sales> Sales { get; set; }

    }
}