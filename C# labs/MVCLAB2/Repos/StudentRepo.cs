using Microsoft.EntityFrameworkCore;
using MVCLAB2.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCLAB2.Repos
{
    public class StudentRepo : IEntities<Student>
    {
        ITIContextcs context = new ITIContextcs();
        public List<Student> GetAll()
        {
            return context.students.Include(s => s.department).ToList();
        }

        public Student GetById(int id)
        {
            return context.students.Include(s => s.department).FirstOrDefault(s => s.id == id);
        }

        public void Add(Student entity)
        {
            context.students.Add(entity);
            context.SaveChanges();
        }

        public void Update(Student entity)
        {
            var existingStudent = context.students.FirstOrDefault(s => s.id == entity.id);
            if (existingStudent != null)
            {
                existingStudent.name = entity.name;
                existingStudent.age = entity.age;
                existingStudent.deptId = entity.deptId;
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var student = context.students.FirstOrDefault(s => s.id == id);
            if (student != null)
            {
                context.students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
