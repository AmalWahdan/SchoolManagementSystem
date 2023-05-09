using SchoolSystem.Models;

namespace SchoolSystem.Repository
{
    public interface IUserRepo
    {
        Task<List<ApplicationUser>> GetUsersInRoleAsync(string roleName);
        Task<List<ApplicationUser>> GetStudentsByClassAndLevelAsync(int classId, int levelId);
        Task<ApplicationUser> GetStudentByIdAsync(string id);
        Task<ApplicationUser> GetTeacherByIdAsync(string id);

        Task UpdateUserAsync(ApplicationUser user);


    }
}
