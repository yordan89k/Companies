using CompaniesYK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CompaniesYK.DataAccess.InMemory
{
    public class StoreRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Store> stores;

        public StoreRepository()
        {
            stores = cache["stores"] as List<Store>;
            if (stores == null)
            {
                stores = new List<Store>();
            }

        }

        public void Commit()
        {
            cache["stores"] = stores;
        }

        public void Insert(Store p)
        {
            stores.Add(p);
        }

        public void Update(Store store)
        {
            Store storeToUpdate = stores.Find(p => p.Id == store.Id);

            if (storeToUpdate != null)
            {
                storeToUpdate = store;
            }
            else
            {
                throw new Exception("Store not found");
            }
        }

        public Store Find(string Id)
        {
            Store store = stores.Find(p => p.Id == Id);

            if (store != null)
            {
                return store;
            }
            else
            {
                throw new Exception("Company not found");
            }
        }

        public IQueryable<Store> Collection()
        {
            return stores.AsQueryable();
        }

        public void Delete(string Id)
        {
            {
                Store storeToDelete = stores.Find(p => p.Id == Id);

                if (storeToDelete != null)
                {
                    stores.Remove(storeToDelete);
                }
                else
                {
                    throw new Exception("Store not found");
                }
            }
        }





    }
}