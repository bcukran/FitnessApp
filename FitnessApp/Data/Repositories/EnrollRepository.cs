using FitnessApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitnessApp.Data.Repositories
{
    public class EnrollRepository
    {
        private readonly FitnessDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public EnrollRepository(FitnessDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public Enroll? Get(int id)
        {
            return _context.Enrolls.FirstOrDefault(x => x.Id == id);
        }

        public List<Enroll> GetListByUserId()
        {
            if (_accessor.HttpContext == null)
                return new List<Enroll>();

            if (_accessor.HttpContext.User == null)
                return new List<Enroll>();

            var userId = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return new List<Enroll>();

            return _context.Enrolls
                .Include(x => x.Course)
                .Where(x => x.UserId == userId)
                .ToList();   
        }

        public List<Enroll> GetListByCourseId(int id)
        {
            return _context.Enrolls
                .Include(x => x.User)
                .Where(x => x.CourseId == id)
                .ToList();
        }

        public void Add(Course course)
        {
            if (_accessor.HttpContext == null)
                return;

            if (_accessor.HttpContext.User == null)
                return;

            var userId = _accessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return;

            var enroll = new Enroll
            {
                CourseId = course.Id,
                UserId = userId
            };

            _context.Enrolls.Add(enroll);
            _context.SaveChanges();
        }

        public void Remove(Enroll enroll)
        {
            _context.Enrolls.Remove(enroll);
            _context.SaveChanges();
        }
    }
}
