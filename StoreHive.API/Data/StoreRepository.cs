using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreHive.API.Models;

namespace StoreHive.API.Data
{
    public class StoreRepository : IStoreRepository
    {
        private readonly AppDbContext context;
        public StoreRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Store>> GetAllStores()
        {
            return await this.context.Stores.OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<Store> GetStore(int id)
        {
            return await this.context.Stores.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> Save()
        {
            var saved = await this.context.SaveChangesAsync();
            return saved >= 0? true : false;
        }
    }
}