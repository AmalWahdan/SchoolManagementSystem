using SchoolSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.ViewModels
{
    public class StudentIndexViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string? ClassName { get; set; }
        public string? LevelName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string Photo { get; set; }
        public List<Attendance> Attendances { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<Holiday> Holidays { get; set; }

    }
}
