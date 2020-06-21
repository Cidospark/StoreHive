using System.Collections.Generic;
using System.Threading.Tasks;
using StoreHive.API.Models;

namespace StoreHive.API.Data
{
    public interface IStoreRepository
    {
         Task<bool> Save();
         Task<List<Store>> GetAllStores();
         Task<Store> GetStore(int id);
    }
}