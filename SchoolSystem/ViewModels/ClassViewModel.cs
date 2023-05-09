using SchoolSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Number of seats is required!")]
        [Range(1,100,ErrorMessage = "Number of seats must be between 1 and 100")]
        public int Seat { get; set; }
        [Required(ErrorMessage = "Select Level")]
        public int? levelID_fk { get; set; }
        public virtual List<Level> Levels { get; set; }
    }
}
