using SchoolSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.ViewModels
{
    public class StudentViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public IFormFile Photo { get; set; }

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password not matched")]
        public string ConfirmPassword { get; set; }

        public int? levelID_fk { get; set; }
        public int? classID_fk { get; set; }

        public virtual List<Level> Levels { get; set; }
        public virtual List<Classes> Classes { get; set; }
    }
}
