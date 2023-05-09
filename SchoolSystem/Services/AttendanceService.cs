using App.Repos;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Migrations;
using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public class AttendanceService:IAttendanceService
    {
        private readonly IRepository<Attendance> _attendanceRepository;
        public AttendanceService(IRepository<Attendance> attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public List<Attendance> GetAttendacesByStdId(string stdId, int month)
        {
            return _attendanceRepository.GetAll().Where(a=>a.userID_fk==stdId && a.Date.Month==month && a.Date.Year==DateTime.Now.Year).ToList();


        }
        public async Task<List<Attendance>> GetAttendacesByDate(int levelId, int classId, DateTime date)
        {
            return await _attendanceRepository.GetAll()
                .Where(a => a.Date.Year == date.Year && a.Date.Month == date.Month && a.Date.Day == date.Day && a.ApplicationUser.levelID_fk == levelId && a.ApplicationUser.classID_fk == classId)
                .ToListAsync();
        }


        public void AddAttendance(Attendance attendance)
        {
            
             _attendanceRepository.Insert(attendance);
           
        }

        public void Save()
        {
            _attendanceRepository.Save();
        }

    }
}
