using Microsoft.AspNetCore.Identity;
using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SchoolDB _context;

        public UserRepo(UserManager<ApplicationUser> userManager, SchoolDB context)
        {
            _userManager = userManager;
            _context = context;
        }
        public async Task<List<ApplicationUser>> GetStudentsByClassAndLevelAsync(int classId, int levelId)
        {
            
            var users = await _userManager.GetUsersInRoleAsync("Student");
            var students = users.Where(u => u.classID_fk == classId && u.levelID_fk == levelId).ToList();
            return students;
        }


    
        public async Task<List<ApplicationUser>> GetUsersInRoleAsync(string roleName)
        {
            var users = await _userManager.GetUsersInRoleAsync(roleName);
            return users.ToList();
        }
        public async Task<ApplicationUser> GetTeacherByIdAsync(string id)
        {
            var users = await _userManager.GetUsersInRoleAsync("Teacher");
            var teacher = users.Where(u => u.Id == id).FirstOrDefault();
            return teacher;
        }

        public async Task<ApplicationUser> GetStudentByIdAsync(string id)
        {
            var users = await _userManager.GetUsersInRoleAsync("Student");
            var student = users.Where(u => u.Id==id).FirstOrDefault();
            return student;
        }

        public async Task UpdateUserAsync(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);

        }

    }
}
