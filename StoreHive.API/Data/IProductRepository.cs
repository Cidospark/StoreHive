using System.Collections.Generic;
using System.Threading.Tasks;
using StoreHive.API.Models;

namespace StoreHive.API.Data
{
    public interface IProductRepository
    {
        Task<bool> Save();
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
    }
}