using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    public enum StatusType { Pending,Rejected,Accepted}
    public class Holiday
    {
        public int  Id { get; set; }
        public string Reason { get; set; }
        [Range(1,15)]
        [DisplayName("Number of Days")]
        public int DaysNum { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
        public StatusType Status { get; set; }

        [ForeignKey("ApplicationUser")]
        public string userID_fk { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
