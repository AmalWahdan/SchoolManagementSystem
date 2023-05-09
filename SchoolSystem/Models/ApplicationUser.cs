using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set;}
        public DateTime BirthDate { get; set;}
        public string Name { get; set;}
        public string? photoUrl { get; set;}
        public Gender Gender { get; set; }

        [ForeignKey("Level")]
        public int? levelID_fk { get; set; }

        //public AttendanceStatus attendanceStatus { get; set; } = AttendanceStatus.Present;

        [ForeignKey("Classes")]
        public int? classID_fk { get; set; }
        public virtual Classes Classes { get; set; }
        public virtual Level Level { get; set; }

    }
}

