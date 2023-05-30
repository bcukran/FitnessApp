using FitnessApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitnessApp.Data.Repositories
{
    public class CourseRepository
    {
        private readonly FitnessDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public CourseRepository(FitnessDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public void Add(Course course)
        {
            _context.Add(course);
            _context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? Get(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public Course? GetWithEnrolledById(int id)
        {
            //if (_accessor.HttpContext == null)
            //    return null;

            //if (_accessor.HttpContext.User == null)
            //    return null;

            //var userId = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (userId == null)
            //    return null;

            return _context.Courses
                .Include(x => x.Enrolls)
                .FirstOrDefault(x => x.Id == id);
        }

        public Course Update(Course course) 
        {
            _context.Courses.Update(course);
            _context.SaveChanges();

            return course;
        }

        public void Remove(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }
    }
}
