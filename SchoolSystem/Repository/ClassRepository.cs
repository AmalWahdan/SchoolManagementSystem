using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Repository
{
    public class ClassRepository:IClassRepository
    {
        SchoolDB context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ClassRepository(SchoolDB _context, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)//inject context from Program.cs
        {
            context = _context;
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public async Task<bool> AddClass(ClassViewModel classVM)
        {
            try
            {
                Classes clas = new Classes();
                clas.Name = classVM.Name;
                clas.Seat = classVM.Seat;
                clas.levelID_fk = classVM.levelID_fk;
                context.Classes.Add(clas);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Classes GetClassByID(int? id)
        {
            return context.Classes.Where(x => x.Id == id).FirstOrDefault();
        }
        public async Task<List<Classes>> GetClasses()
        {
            //return context.Classes.Select(x => new { levelName = x.Level.Name, x.Name, x.Id, x.Seat, x.levelID_fk }).ToList();

            return context.Classes.Include(x=>x.Level).ToList();
        }

        public bool UpdateClass(ClassViewModel classVM)
        {
            try
            {
                Classes clas = new Classes();
                clas.Id = classVM.Id;
                clas.Name = classVM.Name;
                clas.Seat = classVM.Seat;
                clas.levelID_fk = classVM.levelID_fk;
                context.Classes.Update(clas);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteClass(int? id)
        {
            try
            {
                Classes clas = context.Classes.Where(x => x.Id == id).FirstOrDefault();
                context.Classes.Remove(clas);
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
