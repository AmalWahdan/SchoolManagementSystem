using SchoolSystem.Migrations;
using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public interface IAttendanceService
    {
        List<Attendance> GetAttendacesByStdId(string stdId, int month);
        Task<List<Attendance>> GetAttendacesByDate(int levelId, int classId, DateTime date);
        
        void AddAttendance(Attendance attendance);
        void Save();
    }
}
