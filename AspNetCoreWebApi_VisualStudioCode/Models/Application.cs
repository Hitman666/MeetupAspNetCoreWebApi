using System.ComponentModel.DataAnnotations;
using VisualStudioCodeDotNetCore_Sample.Helper;

namespace VisualStudioCodeDotNetCore_Sample.Models
{
    public class Application
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "Ime je obavezno!")]
        public string Firstname {get; set;}
        [Required(ErrorMessage = "Prezime je obavezno!")]
        public string Lastname {get; set;}
        public ShirtSize ShirtSize {get; set;}
    }
}