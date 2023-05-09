using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.ViewModels
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "UserName ")]

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; } 


    }
}
