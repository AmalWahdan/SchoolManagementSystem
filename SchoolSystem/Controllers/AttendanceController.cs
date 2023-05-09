using App.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Migrations;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.Services;
using SchoolSystem.ViewModels;
using System.Runtime.Intrinsics.X86;

namespace SchoolSystem.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IUserRepo _userRepository;
        private readonly IHolidayService _holidayService;
        private readonly ILevelService _levelService;
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService, IUserRepo userRepository,ILevelService levelService, IHolidayService holidayService)
        {
            _attendanceService = attendanceService;
            _userRepository = userRepository;
            _levelService = levelService;
            _holidayService = holidayService;
        }


        // GET: AttendanceController
        public ActionResult Index()
        {
            return View();
        }
       

      

       

       

    }
}
