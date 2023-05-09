using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolSystem.Models
{
    public class Classes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Seat { get; set; }

        [ForeignKey("Level")]
        public int? levelID_fk { get; set; }
        public virtual Level Level { get; set; }
    }
}
