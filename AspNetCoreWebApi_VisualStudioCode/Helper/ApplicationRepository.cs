using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using VisualStudioCodeDotNetCore_Sample.Models;

namespace VisualStudioCodeDotNetCore_Sample.Helper
{
    public class ApplicationRepository : IApplicationRepository
    {
        private ConcurrentDictionary<int, Application> storage = new ConcurrentDictionary<int, Application>();

        public Application Add(Application Application)
        {
            Application.Id = storage.Count == 0 ? 1 : GetAll().Max(it => it.Id) + 1;
            if (storage.TryAdd(Application.Id, Application))
            {
                return Application;
            }
            throw new Exception("Application could not be added");
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

        public bool Delete(int Id)
        {
            Application app;
            return storage.TryRemove(Id, out app);
        }
    }
}