using System.Collections.Generic;
using VisualStudioCodeDotNetCore_Sample.Models;

namespace VisualStudioCodeDotNetCore_Sample.Helper
{
    public interface IApplicationRepository
    {
        Application Add(Application Application);
         Application Get(int Id);
         ICollection<Application> GetAll();

         bool Delete(int Id);
    }
}