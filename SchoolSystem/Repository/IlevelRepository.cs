using SchoolSystem.Models;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Repository
{
    public interface IlevelRepository
    {
        Task<List<Level>> GetLevels();
        string GetLevelByID(int? id);
        bool UpdateLevel(LevelViewModel level);
        bool DeleteLevel(int? id);
        Task<bool> AddLevel(LevelViewModel level);
    }
}
