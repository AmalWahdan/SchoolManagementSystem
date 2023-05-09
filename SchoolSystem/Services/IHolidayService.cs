using SchoolSystem.Models;

namespace SchoolSystem.Services
{
    public interface IHolidayService
    {
        List<Holiday> GetAllHolidays();
        List<Holiday> GetAllPenddingHolidays();
        Holiday GetHolidayById(int id);
        int GetPenddingHolidaysNumpers();

        void updateHoliday(Holiday holiday);

        void Save();
        


    }
}
