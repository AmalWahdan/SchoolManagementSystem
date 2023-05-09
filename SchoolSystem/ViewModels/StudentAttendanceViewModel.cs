using SchoolSystem.Models;

namespace SchoolSystem.ViewModels
{
    public class StudentAttendanceViewModel
    {
        public ApplicationUser Student { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }

    }
}
