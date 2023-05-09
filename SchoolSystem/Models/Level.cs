namespace SchoolSystem.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Classes> Classes { get; set; }

    }
}
