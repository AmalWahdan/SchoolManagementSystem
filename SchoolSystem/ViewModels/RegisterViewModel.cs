using SchoolSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "UserName ")]

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string photoUrl { get; set; }
        public Gender Gender { get; set; }
        //public AttendanceStatus attendanceStatus { get; set; } = AttendanceStatus.Present;
    }
}
