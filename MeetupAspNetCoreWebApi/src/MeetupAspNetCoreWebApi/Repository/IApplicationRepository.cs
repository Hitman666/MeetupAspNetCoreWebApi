using MeetupAspNetCoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAspNetCoreWebApi.Repository
{
    public interface IApplicationRepository
    {
        ICollection<Application> GetAll();
        Application Get(int Id);
        bool Delete(int Id);
        Application Add(Application Application);
    }
}
