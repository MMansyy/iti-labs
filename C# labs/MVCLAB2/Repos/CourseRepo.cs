using Microsoft.EntityFrameworkCore;
using MVCLAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVCLAB2.Repos
{
    public class CourseRepo : IEntities<Course>
    {

        ITIContextcs context;

        public CourseRepo(ITIContextcs context)
        {
            this.context = context;
        }


        public void Add(Course entity)
        {
            var isExist = context.courses.Include(c => c.department).FirstOrDefault(c => c.courseId == entity.courseId);
            if (isExist == null)
            {
                context.courses.Add(entity);
                context.SaveChanges();
            }
            else
            {
                throw new System.Exception("Course already exists");
            }
        }
        public void Delete(int id)
        {
            var isExist = context.courses.Include(c => c.department).FirstOrDefault(c => c.courseId == id);
            if (isExist == null)
            {
                throw new System.Exception("Course not found");
            }
            else
            {
                context.courses.Remove(isExist);
                context.SaveChanges();
            }
        }

        public List<Course> GetAll(Expression<Func<Course, bool>> filter = null)
        {
            if (filter != null)
            {
                return context.courses.Include(c => c.department).Where(filter).ToList();
            }

            return context.courses.Include(c => c.department).ToList();
        }

        public Course GetById(int id)
        {
            var course = context.courses.Include(c => c.department).FirstOrDefault(c => c.courseId == id);
            if (course == null)
            {
                throw new System.Exception("Course not found");
            }
            return course;
        }

        public void Update(Course entity)
        {
            var isExist = context.courses.Include(c => c.department).FirstOrDefault(c => c.courseId == entity.courseId);
            if (isExist == null)
            {
                throw new System.Exception("Course not found");
            }
            else
            {
                isExist.name = entity.name;
                isExist.capacity = entity.capacity;
                isExist.deptID = entity.deptID;
                context.SaveChanges();
            }
        }
    }
}
