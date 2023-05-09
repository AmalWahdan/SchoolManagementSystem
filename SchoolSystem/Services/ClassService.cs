using App.Repos;
using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public class ClassService : IClassService
    { 
        private readonly IRepository<Classes> _classRepository;
        public ClassService(IRepository<Classes> classRepository)
        {
            _classRepository = classRepository;
        }
        public string GetClassName(int id)
        {
            Classes stClass =_classRepository.GetById(id);
            return stClass.Name;
        }
    }
}
