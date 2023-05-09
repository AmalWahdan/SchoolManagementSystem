using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Repository
{
    public class levelRepository:IlevelRepository
    {
        SchoolDB context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public levelRepository(SchoolDB _context, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)//inject context from Program.cs
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public async Task<bool> AddLevel(LevelViewModel levelVM)
        {
            try
            {
                Level level = new Level();
                level.Name = levelVM.Name;

                context.Levels.Add(level);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetLevelByID(int? id)
        {
            return context.Levels.Where(x => x.Id == id).Select(l => l.Name).FirstOrDefault();
        }
        public async Task<List<Level>> GetLevels()
        {
            return context.Levels.Include(x=>x.Classes).ToList();
        }

        public bool UpdateLevel(LevelViewModel levelVM)
        {
            try
            {
                Level level = new Level();
                level.Id = levelVM.Id;
                level.Name = levelVM.Name;
                context.Levels.Update(level);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteLevel(int? id)
        {
            try
            {
                Level level = context.Levels.Where(x => x.Id == id).FirstOrDefault();
                context.Levels.Remove(level);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
