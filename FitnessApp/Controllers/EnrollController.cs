using FitnessApp.Data.Repositories;
using FitnessApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.Controllers
{
    [Authorize(Roles = "Admin,Member")]
    public class EnrollController : Controller
    {
        private readonly EnrollRepository _enrollRepository;
        private readonly CourseRepository _courseRepository;

        public EnrollController(EnrollRepository enrollRepository, CourseRepository courseRepository)
        {
            _enrollRepository = enrollRepository;
            _courseRepository = courseRepository;
        }

        //[Authorize(Roles = "Admin,Member")]
        public IActionResult Index()
        {
            var list = _enrollRepository.GetListByUserId();

            var vmList = new List<CourseVm>();
            foreach (var item in list)
            {
                var vm = new CourseVm
                {
                    Id = item.Id,
                    Name = item.Course.Name,
                    Description = item.Course.Description,
                    Duration = item.Course.Duration
                };
                vmList.Add(vm);
            }

            return View(vmList);
        }

        public IActionResult Enrollers(int id)
        {
            var course = _courseRepository.Get(id);
            if (course == null)
                return NotFound();

            var list = _enrollRepository.GetListByCourseId(id);

            var vmList = new List<EnrollerVm>();
            foreach (var item in list)
            {
                var vm = new EnrollerVm
                {
                    FirstName = item.User.FirstName,
                    LastName = item.User.LastName,
                    Email = item.User.Email
                };
                vmList.Add(vm);
            }

            ViewBag.Title = $"Course {course.Name} {course.Description}";

            return View(vmList);
        }

        //[Authorize(Roles = "Admin,Member")]
        public IActionResult Enroll(int id)
        {
            var course = _courseRepository.Get(id);
            if (course == null)
                return NotFound();

            _enrollRepository.Add(course);

            return RedirectToAction("Index", "Course");
        }

        //[Authorize(Roles = "Admin,Member")]
        public IActionResult UnEnroll(int id)
        {
            var enroll = _enrollRepository.Get(id);
            if (enroll == null)
                return NotFound();

            _enrollRepository.Remove(enroll);

            return RedirectToAction("Index", "Course");
        }
    }
}
