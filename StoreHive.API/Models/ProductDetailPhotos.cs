namespace StoreHive.API.Models
{
    public class ProductDetailPhotos
    {
        public int Id { get; set; }
        public ProductDetail ProductDetail { get; set; }
        public int ProductDetailId { get; set; }
        public string PhotoUrl { get; set; }
    }
}