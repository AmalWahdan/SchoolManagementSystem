using SchoolSystem.Models;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Repository
{
    public interface IAdminRepository
    {
        Task<bool> AddTeacher(TeacherViewModel teacher);
        Task<bool> AddStudent(StudentViewModel student);  
        List<FeedbackVM> GetFeedbacks();
        bool AddFeedback(FeedbackVM feedback);

        Task<bool> UpdateStudent(StudentViewModel student);
        Task<bool> DeleteStudent(string id);
        Task<StudentViewModel> GetStudentByID(StudentViewModel student);
        

    }
}
