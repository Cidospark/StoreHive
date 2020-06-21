using System.Collections.Generic;

namespace StoreHive.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public Store Store { get; set; }
        public int StoreId { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
    }
}