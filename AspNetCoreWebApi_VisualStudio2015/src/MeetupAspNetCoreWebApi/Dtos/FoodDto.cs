using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAspNetCoreWebApi.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Previše kalorija!")]
        public int Calories { get; set; }
        public DateTime Created { get; set; }
    }
}
