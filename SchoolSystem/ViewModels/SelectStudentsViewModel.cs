using SchoolSystem.Models;

namespace SchoolSystem.ViewModels
{
    public class SelectStudentsViewModel
    {
        public int id { get; set; }
        public int LevelId { get; set; }
        public int ClassId { get; set; }
        public List<Classes> classes { get; set; }
        public List<Level> levels { get; set; }

    }
}
