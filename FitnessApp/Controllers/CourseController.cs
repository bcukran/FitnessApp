using FitnessApp.Data.Repositories;
using FitnessApp.Entities;
using FitnessApp.Models;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FitnessApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseRepository _repository;

        public CourseController(CourseRepository repository)
        {
            _repository = repository;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            var list = _repository.GetAll();

            var vmList = new List<CourseVm>();
            foreach (var item in list)
            {
                var vm = new CourseVm
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Duration = item.Duration
                };
                vmList.Add(vm);
            }

            return View(vmList);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            var course = _repository.GetWithEnrolledById(id);
            if (course == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int? enrollId = null;
            var enroll = course.Enrolls.FirstOrDefault(x => x.CourseId == course.Id && x.UserId == userId);
            if (enroll != null)
                enrollId = enroll.Id;

            var model = new CourseDetailsVm 
            { 
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration,
                EnrollId = enrollId
            };

            return View(model);
        }

        // GET: CourseController/Create
        [Authorize (Roles = "Admin")]
        public ActionResult Create()
        {
            var model = new AddCourseVm();

            return View(model);
        }

        // POST: CourseController/Create
        [Authorize (Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddCourseVm model)
        {
            try
            {
                var entity = new Course
                {
                    Name = model.Name,
                    Description = model.Description,
                    Duration = model.Duration
                };

                _repository.Add(entity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        [Authorize (Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var course = _repository.Get(id);
            if (course == null)
                return NotFound();

            var model = new CourseVm
            {
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration
            };

            return View(model);
        }

        // POST: CourseController/Edit/5
        [Authorize (Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseVm model)
        {
            if (id != model.Id)
                return BadRequest();

            try
            {
                var entity = _repository.Get(id);
                if (entity == null)
                    return NotFound();

                entity.Name = model.Name;
                entity.Description = model.Description;
                entity.Duration = model.Duration;

                _repository.Update(entity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        [Authorize (Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var course = _repository.Get(id);
            if (course == null)
                return NotFound();

            var model = new CourseVm
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Duration = course.Duration
            };

            return View(model);
        }

        // POST: CourseController/Delete/5
        [Authorize (Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CourseVm model)
        {
            if (id != model.Id)
                return BadRequest();

            try
            {
                var entity = _repository.Get(id);
                if (entity == null)
                    return NotFound();

                _repository.Remove(entity);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
