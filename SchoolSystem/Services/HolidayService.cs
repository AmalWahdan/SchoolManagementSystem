using App.Repos;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public class HolidayService: IHolidayService
    {
        private readonly IRepository<Holiday> _holidayRepository;
        public HolidayService(IRepository<Holiday> holidayRepository)
        {
            _holidayRepository = holidayRepository;

        }
        public List<Holiday> GetAllHolidays()
        {
            return _holidayRepository.GetAll().Include(h=>h.ApplicationUser).ToList();
        }
        public List<Holiday> GetAllPenddingHolidays()
        {
            return _holidayRepository.GetAll().Include(h => h.ApplicationUser).Where(h => h.Status == StatusType.Pending).ToList();
        }
        public int GetPenddingHolidaysNumpers()
        {
            return  _holidayRepository.GetAll().Include(h => h.ApplicationUser).Where(h=>h.Status == StatusType.Pending).ToList().Count();
           
        }

        public Holiday GetHolidayById(int id)
        {
            return _holidayRepository.GetAll().FirstOrDefault(h => h.Id == id);
        }

        public void updateHoliday(Holiday holiday)
        {
             _holidayRepository.Update(holiday);
             
        }
        public void Save()
        {
            _holidayRepository.Save();
        }


    }
}
