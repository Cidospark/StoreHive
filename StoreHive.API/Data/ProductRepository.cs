using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreHive.API.Models;

namespace StoreHive.API.Data
{
    public class ProductRepository : IProductRepository
    {

        private readonly AppDbContext context;
        public ProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            
            //return await this.context.Products.OrderByDescending(x => x.Id).ToListAsync();
            var result = await (from p in this.context.Products
                          join c in this.context.Categories on p.CategoryId equals c.Id
                          join s in this.context.Stores on p.StoreId equals s.Id
                          select new Product {
                              Id = p.Id,
                              Name = p.Name,
                              Brand = p.Brand,
                              Category = new Category { Id = c.Id, Name = c.Name },
                              CategoryId = c.Id,
                              Store = new Store { Id = s.Id, Name = s.Name, Logo = s.Logo},
                              StoreId = p.StoreId,
                              DetailedDescription = p.DetailedDescription
                          }).OrderByDescending(x => x.Id).ToListAsync();
            return result;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<bool> Save()
        {
            var saved = await this.context.SaveChangesAsync();
            return saved >= 0 ? true : false;
        }
    }
}