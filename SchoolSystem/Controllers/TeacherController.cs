using App.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.Services;
using SchoolSystem.ViewModels;
using System.Security.Claims;

namespace SchoolSystem.Controllers
{
    public class TeacherController : Controller
    { 
        private readonly IRepository<ApplicationUser> _teacherRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepo _userRepo;
        private readonly IHolidayService _holidayService;
        private readonly ILevelService _levelService;
        private readonly IAttendanceService _attendanceService;
        public TeacherController(IRepository<ApplicationUser> teacherRepository, IUserRepo userRepo,IWebHostEnvironment webHostEnvironment, IAttendanceService attendanceService, ILevelService levelService, IHolidayService holidayService)
        {
            _teacherRepository = teacherRepository;
            _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;
            _attendanceService = attendanceService;   
            _levelService = levelService;
            _holidayService = holidayService;

        }
        public async Task<IActionResult> Index()
        {
           TeacherProfileViewModel teacherProfileViewModel = new TeacherProfileViewModel();
           teacherProfileViewModel.applicationUser = await _userRepo.GetTeacherByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
           teacherProfileViewModel.numperOfPendingHolidays = _holidayService.GetPenddingHolidaysNumpers();
           return View(teacherProfileViewModel);
        }
    
        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public ActionResult AttendancePage()
        {
            SelectStudentsViewModel vm = new SelectStudentsViewModel();
            vm.levels = _levelService.GetAllLevels();
            return View(vm);
        }
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> TakeAttendance(int classId, int levelId)
        {
            var students = await _userRepo.GetStudentsByClassAndLevelAsync(classId, levelId);
            return PartialView("TakeAttendance", students);

        }
        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public ActionResult TakeAttendance(List<ApplicationUser> students)
        {

            if (ModelState.IsValid)
            {
                var attendanceStatuses = Request.Form["AttendanceStatus"];
                var studentIds = Request.Form["student.Id"];

                for (int i = 0; i < attendanceStatuses.Count; i++)
                {
                    Attendance attendance = new Attendance();
                    AttendanceStatus status;
                    if (Enum.TryParse(attendanceStatuses[i], out status))
                    {
                        attendance.AttendanceStatus = status;
                    }
                    else
                    {
                        attendance.AttendanceStatus = AttendanceStatus.Present;

                    }

                    attendance.userID_fk = studentIds[i];
                    _attendanceService.AddAttendance(attendance);
                }
                _attendanceService.Save();

                return RedirectToAction("AttendanceListLevels");
            }

            return PartialView("TakeAttendance", students);

        }

        ///  List Of Attendance
        [Authorize(Roles = "Teacher")]
        public ActionResult AttendanceListLevels()
        {
            SelectStudentsViewModel vm = new SelectStudentsViewModel();
            vm.levels = _levelService.GetAllLevels();
            return View(vm);
        }


        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AttendanceList(int levelId, int classId, DateTime date)
        {

            var students = await _userRepo.GetStudentsByClassAndLevelAsync(classId, levelId);
            var attendanceRecords = await _attendanceService.GetAttendacesByDate(levelId, classId, date);

            var studentAttendanceList = new List<StudentAttendanceViewModel>();

            if (attendanceRecords.Count > 0)
            {
                foreach (var student in students)
                {
                    var attendanceRecord = attendanceRecords.FirstOrDefault(a => a.userID_fk == student.Id);

                    var attendanceState = AttendanceStatus.Absent;
                    if (attendanceRecord != null)
                    {
                        attendanceState = (AttendanceStatus)attendanceRecord.AttendanceStatus;
                    }

                    studentAttendanceList.Add(new StudentAttendanceViewModel
                    {
                        Student = student,
                        AttendanceStatus = attendanceState
                    });
                }
            }
            else
            {

                studentAttendanceList.Clear();
            }


            return PartialView(studentAttendanceList);
        }

        /// Holidays
        [Authorize(Roles = "Teacher,Admin")]
        public IActionResult ShowHolidaysRequests()
        {
            List<Holiday> holidays = _holidayService.GetAllPenddingHolidays();
            return View(holidays);

        }
        [Authorize(Roles = "Teacher,Admin")]
        public ActionResult HolidayRequestResponse(int id, int status)
        {
            Holiday holiday = _holidayService.GetHolidayById(id);
            holiday.Status = (StatusType)status;
            _holidayService.updateHoliday(holiday);
            _holidayService.Save();

            return RedirectToAction("ShowHolidaysRequests");
        }
        [Authorize(Roles = "Teacher,Admin")]
        [HttpGet]
        public ActionResult StudentsReports()
        {
            SelectStudentsViewModel vm = new SelectStudentsViewModel();
            vm.levels = _levelService.GetAllLevels();
            return View(vm);
        }
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> ShowStudentReports(int classId, int levelId)
        {
            var students = await _userRepo.GetStudentsByClassAndLevelAsync(classId, levelId);
            return PartialView(students);
        }
        [Authorize(Roles = "Teacher,Admin")]
        [HttpGet]
        public IActionResult GetClassessByLevelID(int id)
        {
            List<Classes> classes = _levelService.GetLevelById(id).Classes;

            return Json(classes);
        }
        /// Updat teacher

        [Authorize(Roles ="Teacher")]
        [HttpGet]
        public async Task<IActionResult> UpdateTeacher()
        {
            string teacherId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            ApplicationUser teacher = await _userRepo.GetTeacherByIdAsync(teacherId);

            TeacherViewModel teacherView = new TeacherViewModel()
            { Name = teacher.Name,
                Address = teacher.Address,
                Phone = teacher.PhoneNumber,
                BirthDate = teacher.BirthDate,
                UserName = teacher.UserName,
                Email = teacher.Email,
                Password = teacher.PasswordHash,
                Filename = teacher.photoUrl

        };
           
            return View( teacherView);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        public async Task<IActionResult> UpdateTeacher(TeacherViewModel teacherVM, IFormFile Photo)
        {
            ApplicationUser teacher = await _userRepo.GetTeacherByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
            teacher.Name = teacherVM.Name;
            teacher.Email = teacherVM.Email;
            teacher.UserName = teacherVM.UserName;
            teacher.Address = teacherVM.Address;
            teacher.PhoneNumber = teacherVM.Phone;
            teacher.photoUrl = teacherVM.Photo.FileName;
            teacher.BirthDate = teacherVM.BirthDate;
            teacher.Gender = teacherVM.Gender;
            teacher.PasswordHash = teacherVM.Password;
            teacher.photoUrl = teacherVM.Photo.FileName;

            if (ModelState.IsValid)
            {
                string filename = string.Empty;
                if (Photo != null)
                {
                    string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    filename = Photo.FileName;
                    string fullpath = Path.Combine(uploads, filename);
                    Photo.CopyTo(new FileStream(fullpath, FileMode.Create));
                }

               await _userRepo.UpdateUserAsync(teacher);
                _teacherRepository.Save();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }
    }
}
