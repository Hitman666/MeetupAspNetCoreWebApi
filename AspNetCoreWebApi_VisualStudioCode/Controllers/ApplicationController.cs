using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VisualStudioCodeDotNetCore_Sample.Helper;
using VisualStudioCodeDotNetCore_Sample.Models;

namespace VisualStudioCodeDotNetCore_Sample.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private IApplicationRepository appRepository;
        
        public ApplicationController(IApplicationRepository ApplicationRepository)
        {
            appRepository = ApplicationRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ICollection<Application> apps = appRepository.GetAll();
            return Ok(apps);            
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int Id)
        {
            Application app = appRepository.Get(Id);
            if (app != null)
            {
                return Ok(app);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Application Application)
        {
            if (Application == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Application created = appRepository.Add(Application);

            return Ok(created);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int Id)
        {
            if (appRepository.Get(Id) == null)
            {
                return BadRequest();
            }
            bool result = appRepository.Delete(Id);
            return Ok(result);
        }
    }
}