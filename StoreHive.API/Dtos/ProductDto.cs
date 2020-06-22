using StoreHive.API.Models;

namespace StoreHive.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public CategoryDto Category { get; set; }
        public StoreForProductDto Store { get; set; }
        public int StoreId { get; set; }
        public string DetailedDescription { get; set; }

    }
}