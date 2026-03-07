using Microsoft.EntityFrameworkCore;
using MVCLAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVCLAB2.Repos
{
    public class DepartmentRepo : IEntities<Department>
    {
        ITIContextcs context;



        public DepartmentRepo(ITIContextcs context)
        {
            this.context = context;
        }

        public List<Department> GetAll(Expression<Func<Department, bool>>? filter = null)
        {
            if (filter != null)
            {
                return context.departments.Where(filter).ToList();
            }
            return context.departments.ToList();
        }
        public Department GetById(int id)
        {
            return context.departments.FirstOrDefault(d => d.deptID == id);
        }
        public void Add(Department entity)
        {
            context.departments.Add(entity);
            context.SaveChanges();
        }
        public void Update(Department entity)
        {
            var existingDepartment = context.departments.FirstOrDefault(d => d.deptID == entity.deptID);
            if (existingDepartment != null)
            {
                existingDepartment.deptName = entity.deptName;
                existingDepartment.capacity = entity.capacity;
                //existingDepartment.deptID = entity.deptID;
                context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var department = context.departments.FirstOrDefault(d => d.deptID == id);
            if (department != null)
            {
                context.departments.Remove(department);
                context.SaveChanges();
            }
        }
    }
}
