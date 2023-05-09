using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    public enum AttendanceStatus
    {
        Absent,
        Present
    }
    public class Attendance
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now.Date;
        [DisplayName("Attendance Status")]
        public AttendanceStatus AttendanceStatus { get; set;}

        [ForeignKey("ApplicationUser")]
        public string userID_fk { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

}
