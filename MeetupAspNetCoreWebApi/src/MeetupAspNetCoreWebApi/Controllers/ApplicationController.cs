using MeetupAspNetCoreWebApi.Models;
using MeetupAspNetCoreWebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAspNetCoreWebApi.Controllers
{
    [Route("api/{controller}")]
    public class ApplicationController
    {
        private IApplicationRepository repository;

        public ApplicationController(IApplicationRepository ApplicationRepository)
        {
            repository = ApplicationRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ICollection<Application> apps = repository.GetAll();
            return Ok(apps);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int Id)
        {
            Application app = repository.Get(Id);
            return Ok(app);
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

            Application app = repository.Add(Application);
            return Ok(app);
        }
    }
}
