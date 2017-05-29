using MeetupAspNetCoreWebApi.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAspNetCoreWebApi.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ConcurrentDictionary<int, FoodItem> storage = new ConcurrentDictionary<int, FoodItem>();

        public FoodItem GetSingle(int Id)
        {
            FoodItem foodItem;
            return storage.TryGetValue(Id, out foodItem) ? foodItem : null;
        }

        public FoodItem Add(FoodItem Item)
        {
            Item.Id = !GetAll().Any() ? 1 : GetAll().Max(it => it.Id) + 1;
            if (storage.TryAdd(Item.Id, Item))
            {
                return Item;
            }

            throw new Exception("Food item could not be added");
        }

        public void Delete(int Id)
        {
            FoodItem item;
            if (!storage.TryRemove(Id, out item))
            {
                throw new Exception("Item couldn't be removed!");
            }
        }

        public FoodItem Update(int Id, FoodItem Item)
        {
            storage.TryUpdate(Id, Item, GetSingle(Id));
            return Item;
        }

        public ICollection<FoodItem> GetAll()
        {
            return storage.Values;
        }

        public int Count()
        {
            return storage.Count;
        }
    }
}
