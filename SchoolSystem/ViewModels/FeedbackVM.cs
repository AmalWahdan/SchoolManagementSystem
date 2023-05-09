using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SchoolSystem.ViewModels
{
    public class FeedbackVM
    {
        public int Id { get; set; }
        public string FeedbackText { get; set; }
        public string? Response { get; set; }
        public string StudentName { get; set; }
    }
}
