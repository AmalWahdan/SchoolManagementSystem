using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.ViewModels
{
    public class TeacherViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }

        public string? Filename { get; set; }
        public IFormFile Photo { get; set; }

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone no.")]
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public Models.Gender Gender { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm Password not matched")]
        public string ConfirmPassword { get; set; }

    }
}
