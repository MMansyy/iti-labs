using Lab_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_1.Repos
{
    public class CourseRepo : ICourseRepo
    {
        private readonly DBContext _context;

        public CourseRepo(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.Find(id);
        }

        public Course? GetByName(string courseName)
        {
            return _context.Courses
                .FirstOrDefault(c => c.Crs_name == courseName);
        }

        public void Add(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Update(Course course)
        {
            var existing = _context.Courses.Find(course.ID);
            _context.Entry(existing).CurrentValues.SetValues(course);
            _context.Entry(existing).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}