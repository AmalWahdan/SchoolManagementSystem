using App.Repos;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public class LevelService : ILevelService
    {
        private readonly IRepository<Level> _levelRepository;
        public LevelService(IRepository<Level> classRepository)
        {
            _levelRepository = classRepository;
           
        }

        public List<Level> GetAllLevels()
        {
            return _levelRepository.GetAll().ToList();
        }

        public Level GetLevelById(int id)
        {
            return _levelRepository.GetAll().Select(l=>new Level {Id=l.Id,Name =l.Name,Classes=l.Classes.Select(c=>new Classes {Id=c.Id,Name=c.Name,Seat=c.Seat }).ToList() }).FirstOrDefault(l => l.Id == id);
        }

        public void AddLevel(Level level)
        {
            _levelRepository.Insert(level);
        }
        public void UpdateLevel(Level level)
        {
            _levelRepository.Update(level);
        }

        public void DeleteLevel(int id)
        {
            _levelRepository.Delete(id);
        }
        public string GetLevelName(int id)
        {
            Level level = _levelRepository.GetById(id);
            return level.Name;
        }

      
    }
}
