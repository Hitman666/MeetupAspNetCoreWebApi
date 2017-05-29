using MeetupAspNetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAspNetCoreWebApi.Repositories
{
    public interface IFoodRepository
    {
        FoodItem GetSingle(int Id);
        FoodItem Add(FoodItem Item);
        void Delete(int Id);
        FoodItem Update(int Id, FoodItem Item);
        ICollection<FoodItem> GetAll();
        int Count();
    }
}
