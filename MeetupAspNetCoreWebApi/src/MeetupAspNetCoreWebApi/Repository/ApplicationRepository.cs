using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetupAspNetCoreWebApi.Models;
using System.Collections.Concurrent;

namespace MeetupAspNetCoreWebApi.Repository
{
    public class ApplicationRepository : IApplicationRepository
    {
        private ConcurrentDictionary<int, Application> storage = new ConcurrentDictionary<int, Application>();

        public Application Add(Application Application)
        {
            Application.Id = storage.Count > 0 ? storage.Values.Max(it => it.Id) + 1 : 1;
            if (storage.TryAdd(Application.Id, Application))
                return Application;
            throw new Exception("Add not successfull!");
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Application Get(int Id)
        {
            Application app;
            return storage.TryGetValue(Id, out app) ? app : null;
        }

        public ICollection<Application> GetAll()
        {
            return storage.Values;
        }
    }
}
