using App.Repos;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public interface ILevelService
    {
        List<Level> GetAllLevels();
        Level GetLevelById(int id);
        void AddLevel(Level level);
        void UpdateLevel(Level level);
        void DeleteLevel(int id);
        public string GetLevelName(int id);

    }
}
