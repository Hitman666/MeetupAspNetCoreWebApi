using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetupAspNetCoreWebApi.Models
{
    public class Application
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Prezime je obavezan podatak!")]
        [MaxLength(10, ErrorMessage = "Previše znakova!")]
        public string Lastname { get; set; }
        public string Firstname { get; set; }
    }
}
