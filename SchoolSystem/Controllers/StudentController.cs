using App.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using SchoolSystem.Models;
using SchoolSystem.Repository;
using SchoolSystem.Services;
using SchoolSystem.ViewModels;
using System.Security.Claims;

namespace SchoolSystem.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        private readonly IRepository<Holiday> _holidayRepository;
        private readonly IRepository<Feedback> _feedbackRepository;
        private readonly IAttendanceService _attendanceService;
        private readonly IUserRepo _userRepo;
        private readonly ILevelService _levelService;
        private readonly IClassService _classService;
        private readonly IRepository<ApplicationUser> _applicationUserRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SignInManager<ApplicationUser> _signInManager;
       
        public StudentController (SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,IClassService classService,
            ILevelService levelService, IUserRepo userRepo, IAttendanceService attendanceService, 
            IRepository<Holiday> holidayRepository, IRepository<Feedback> feedbackRepository,
            IRepository<ApplicationUser> applicationUserRepository,IWebHostEnvironment webHostEnvironment)
        {
            _holidayRepository = holidayRepository;
            _feedbackRepository = feedbackRepository;
            _attendanceService = attendanceService;
            _levelService = levelService;
            _classService = classService;
            _userRepo = userRepo;
            _applicationUserRepository = applicationUserRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            string studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student =await _userRepo.GetStudentByIdAsync(studentId);
            StudentIndexViewModel studentIndexVM=new StudentIndexViewModel();
            studentIndexVM.Name = student.Name;
            studentIndexVM.Address= student.Address;
            studentIndexVM.Phone = student.PhoneNumber;
            studentIndexVM.Photo = student.photoUrl;
            studentIndexVM.Email = student.Email;
            studentIndexVM.Birthday = student.BirthDate.Date;
            if (student.levelID_fk!=null)
                 studentIndexVM.LevelName = _levelService.GetLevelName((int)student.levelID_fk);
            if (student.classID_fk != null)
                studentIndexVM.ClassName=_classService.GetClassName((int)student.classID_fk);
            studentIndexVM.Attendances= _attendanceService.GetAttendacesByStdId(User.FindFirstValue(ClaimTypes.NameIdentifier), DateTime.Now.Month);
            studentIndexVM.Holidays = _holidayRepository.GetAll().Where(h => h.userID_fk == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            studentIndexVM.Feedbacks= _feedbackRepository.GetAll().Where(f => f.userID_fk == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(studentIndexVM);
        }
        public IActionResult AttendanceReportMonth()
        { 
            return View();
        }
        public IActionResult AttendanceReport(int month)
        {
            
            List<Attendance> attendances = _attendanceService.GetAttendacesByStdId(User.FindFirstValue(ClaimTypes.NameIdentifier), month);
            return PartialView(attendances);
        }
        public IActionResult SendFeedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendFeedback(FeedbackViewModel feedbackVM)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback=new Feedback();
                feedback.userID_fk= User.FindFirstValue(ClaimTypes.NameIdentifier);
                feedback.FeedbackText = feedbackVM.FeedbackTxt;
                _feedbackRepository.Insert(feedback);
                _feedbackRepository.Save();
                return RedirectToAction("ViewFeedbacks");
            }
            return View();
        }
        public IActionResult ViewFeedbacks()
        {
            var feedbacks = _feedbackRepository.GetAll().Where(f=>f.userID_fk== User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(feedbacks);
        }
        public IActionResult DeleteFeedback(int id)
        {
            _feedbackRepository.Delete(id);
            _feedbackRepository.Save();
            return RedirectToAction("ViewFeedbacks");
        }
        public IActionResult EditFeedback(int id)
        {
            Feedback feedback = _feedbackRepository.GetById(id);
            FeedbackViewModel feedbackVM= new FeedbackViewModel();
            feedbackVM.FeedbackTxt = feedback.FeedbackText;
            return View(feedbackVM);
        }
        [HttpPost]
        public IActionResult EditFeedback(int id,FeedbackViewModel feedbackVM)
        {
            if (ModelState.IsValid)
            {
                Feedback feedback = _feedbackRepository.GetById(id);
                feedback.FeedbackText = feedbackVM.FeedbackTxt;
                _feedbackRepository.Update(feedback);
                _feedbackRepository.Save();
                return RedirectToAction("ViewFeedbacks");
            }
            return View();
        }
        public IActionResult ApplyHoliday()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ApplyHoliday(HolidayViewModel holidayVM)
        {
            if (ModelState.IsValid)
            {
                Holiday holiday = new Holiday();
                holiday.userID_fk = User.FindFirstValue(ClaimTypes.NameIdentifier);
                holiday.StartDate=holidayVM.StartDate;
                holiday.DaysNum = holidayVM.DaysNum;
                holiday.Reason = holidayVM.Reason;
                holiday.Status = StatusType.Pending;
                _holidayRepository.Insert(holiday);
                _holidayRepository.Save();
                return RedirectToAction("ViewHolidays");
            }    
            return View(holidayVM);
        }

        public IActionResult ViewHolidays()
        {
            var holidays = _holidayRepository.GetAll().Where(h=>h.userID_fk == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();
            return View(holidays);
        }
        public IActionResult DeleteHoliday(int id)
        {
            Holiday holiday=_holidayRepository.GetById(id);
            if (holiday.Status == StatusType.Pending)
            {
                _holidayRepository.Delete(id);
                _holidayRepository.Save();
            }
            return RedirectToAction("ViewHolidays");
        }
        public IActionResult EditHoliday(int id)
        {
            Holiday holiday= _holidayRepository.GetById(id);
            HolidayViewModel holidayVM= new HolidayViewModel();
            holidayVM.StartDate = holiday.StartDate;
            holidayVM.DaysNum = holiday.DaysNum;
            holidayVM.Reason = holiday.Reason;
            return View(holidayVM);
        }
        [HttpPost]
        public IActionResult EditHoliday(int id,HolidayViewModel holidayVM)
        {
            if(ModelState.IsValid)
            {
                Holiday holiday = _holidayRepository.GetById(id);
                holiday.StartDate = holidayVM.StartDate;
                holiday.DaysNum = holidayVM.DaysNum;
                holiday.Reason = holidayVM.Reason;
                _holidayRepository.Update(holiday);
                _holidayRepository.Save();
                return RedirectToAction("ViewHolidays");
            }
            return View(holidayVM);
        }


        public async Task<IActionResult> UpdateProfile()
        {
            string studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var student = await _userRepo.GetStudentByIdAsync(studentId);
            StudentProfileViewModel studentProfileVM = new StudentProfileViewModel();
            studentProfileVM.Name = student.Name;
            studentProfileVM.Address =student.Address;
            studentProfileVM.Phone = student.PhoneNumber;
            studentProfileVM.Email = student.Email;
            studentProfileVM.Filename = student.photoUrl;
          
            return View(studentProfileVM);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(StudentProfileViewModel studentProfileVM, IFormFile Photo)

        {
            string studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
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

                ApplicationUser student = await _userRepo.GetStudentByIdAsync(studentId);
                student.Name = studentProfileVM.Name;
                student.Address = studentProfileVM.Address;
                student.PhoneNumber = studentProfileVM.Phone;
                student.Email = studentProfileVM.Email;
                student.photoUrl = studentProfileVM.Photo.FileName;
                await _userRepo.UpdateUserAsync(student);
                _applicationUserRepository.Save();
                return RedirectToAction("AttendanceReportMonth");
            }
            return View(studentProfileVM);
        }
        public IActionResult UpdatePassword()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordViewModel updatePasswordVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser student = await _userRepo.GetStudentByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _userManager.ChangePasswordAsync(student, updatePasswordVM.OldPassword, updatePasswordVM.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.RefreshSignInAsync(student);
                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);

            }
            return View(updatePasswordVM);
        }




    }
}
