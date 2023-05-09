using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace SchoolSystem.ViewModels
{
    
    public class HolidayViewModel
    {
        public int id { get; set; }
        public string Reason { get; set; }
        [Range(1, 15)]
        [DisplayName("Number of Days")]
        public int DaysNum { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; }
    }
}
