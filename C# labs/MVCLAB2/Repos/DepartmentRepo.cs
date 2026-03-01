using MVCLAB2.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCLAB2.Repos
{
    public class DepartmentRepo : IEntities<Department>
    {
        ITIContextcs context = new ITIContextcs();
        public List<Department> GetAll()
        {
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
                context.departments.Update(entity);
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
