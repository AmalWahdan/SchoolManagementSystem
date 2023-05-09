using SchoolSystem.Models;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Repository
{
    public interface IClassRepository
    {
        Task<List<Classes>> GetClasses();
        Classes GetClassByID(int? id);
        bool UpdateClass(ClassViewModel clas);
        bool DeleteClass(int? id);
        Task<bool> AddClass(ClassViewModel clas);
    }
}
