namespace StoreHive.API.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int UnitPrice { get; set; }
        public int UnitQuantity { get; set; }
        public int PackagePrice { get; set; }
        public int PackageQuantity { get; set; }
        public string PhotoUrl { get; set; }

    }
}