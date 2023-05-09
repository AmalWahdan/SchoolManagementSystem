using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace SchoolSystem.ViewModels
{
    public class FeedbackViewModel
    {
        public  int id { get; set; }

        [DisplayName("FeedBack")]
        public string FeedbackTxt { get; set; }
    }
}
