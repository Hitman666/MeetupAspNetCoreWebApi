using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MeetupAspNetCoreWebApi.Repositories;
using MeetupAspNetCoreWebApi.Models;
using MeetupAspNetCoreWebApi.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace MeetupAspNetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    public class FoodController : Controller
    {
        private readonly IFoodRepository foodRepository;

        public FoodController(IFoodRepository FoodRepository)
        {
            foodRepository = FoodRepository;
        }

        [HttpGet]
        public IActionResult GetAllFoodItems()
        {
            ICollection<FoodItem> foodItems = foodRepository.GetAll();

            IEnumerable<FoodDto> mappedItems = foodItems.Select(it => AutoMapper.Mapper.Map<FoodDto>(it));

            return Ok(mappedItems);
        }

        [HttpGet("{id:int}", Name = "GetSingleFoodItem")]
        public IActionResult GetSingleFoodItem(int Id)
        {
            FoodItem item = foodRepository.GetSingle(Id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(AutoMapper.Mapper.Map<FoodDto>(item));
        }

        [HttpPost]
        public IActionResult AddNewFoodItem([FromBody] FoodDto FoodDto)
        {
            if (FoodDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FoodItem created = foodRepository.Add(AutoMapper.Mapper.Map<FoodItem>(FoodDto));

            return CreatedAtRoute("GetSingleFoodItem", new { id = created.Id }, AutoMapper.Mapper.Map<FoodDto>(created));
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int Id, [FromBody] FoodDto FoodDto)
        {
            if (Id != FoodDto.Id)
            {
                return BadRequest("Krivi zahtjev!");
            }

            FoodItem item = foodRepository.GetSingle(Id);
            if (item == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FoodItem updated = foodRepository.Update(Id, AutoMapper.Mapper.Map<FoodItem>(FoodDto));

            return Ok(AutoMapper.Mapper.Map<FoodDto>(updated));
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartialUpdate(int Id, 
            [FromBody] JsonPatchDocument<FoodDto> FoodDtoPatchDocument)
        {
            if (FoodDtoPatchDocument == null)
            {
                return BadRequest();
            }

            FoodItem item = foodRepository.GetSingle(Id);
            if (item == null)
            {
                return NotFound();
            }

            FoodDto dto = AutoMapper.Mapper.Map<FoodDto>(item);
            FoodDtoPatchDocument.ApplyTo(dto, ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            FoodItem updated = foodRepository.Update(Id, AutoMapper.Mapper.Map<FoodItem>(dto));

            return Ok(AutoMapper.Mapper.Map<FoodDto>(updated));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int Id)
        {
            FoodItem item = foodRepository.GetSingle(Id);
            if (item == null)
            {
                return NotFound();
            }

            foodRepository.Delete(Id);

            return NoContent();
        }
    }
}
