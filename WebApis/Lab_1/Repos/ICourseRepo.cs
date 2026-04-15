using Lab_1.Models;

namespace Lab_1.Repos
{
    public interface ICourseRepo
    {
        IEnumerable<Course> GetAll();

        Course? GetById(int id);

        Course? GetByName(string courseName);

        void Add(Course course);

        void Update(Course course);

        void Delete(int id); 

        void Save();
    }
}