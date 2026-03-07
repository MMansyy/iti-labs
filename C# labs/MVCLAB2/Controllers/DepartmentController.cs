using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCLAB2.Models;
using MVCLAB2.Repos;
using System.Collections.Generic;
using System.Linq;

namespace MVCLAB2.Controllers
{

    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        IEntities<Department> departmentRepo;
        IEntities<Course> courseRepo;
        IEntities<Student> studentRepo;


        public DepartmentController(IEntities<Department> departmentRepo, IEntities<Course> courseRepo, IEntities<Student> studentRepo)
        {
            this.departmentRepo = departmentRepo;
            this.courseRepo = courseRepo;
            this.studentRepo = studentRepo;
        }


        public IActionResult Index()
        {
            return View(departmentRepo.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dept)
        {
            var isExist = departmentRepo.GetById(dept.deptID);
            if (ModelState.IsValid && isExist == null)
            {
                departmentRepo.Add(dept);
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var dept = departmentRepo.GetById(id);
            if (dept == null) return NotFound();

            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            if (ModelState.IsValid)
            {
                departmentRepo.Update(dept);
                return RedirectToAction("Index");
            }
            return View(dept);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var dept = departmentRepo.GetById(id);
            if (dept == null) return NotFound();

            return View(dept);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int deptID)
        {
            departmentRepo.Delete(deptID);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var dept = departmentRepo.GetById(id);
            if (dept == null) return NotFound();

            return View(dept);
        }

        [HttpGet]
        public IActionResult Courses(int id)
        {
            var dept = departmentRepo.GetById(id);
            if (dept == null) return NotFound();
            var courses = courseRepo.GetAll(c => c.deptID == id);
            ViewBag.DepartmentName = dept.deptName;
            return View(courses);
        }

        [HttpGet]
        public IActionResult Students(int id, int deptID)
        {

            var dept = departmentRepo.GetById(deptID);
            if (dept == null) return NotFound();

            var students = studentRepo.GetAll(s => s.deptId == deptID);

            ViewBag.CourseId = id;
            ViewBag.DepartmentName = dept.deptName;

            return View(students);
        }

        [HttpPost]
        public IActionResult UpdateDegrees(Dictionary<int, int> degrees, int courseId, int deptID, [FromServices] ITIContextcs context)
        {

            foreach (var entry in degrees)
            {
                int studentId = entry.Key;
                int degree = entry.Value;

                var studentCourse = context.studentCourses
                    .FirstOrDefault(sc => sc.studentId == studentId && sc.courseId == courseId);

                if (studentCourse == null)
                {
                    studentCourse = new StudentCourse
                    {
                        studentId = studentId,
                        courseId = courseId,
                        degree = degree
                    };
                    context.studentCourses.Add(studentCourse);

                }
                else
                {
                    studentCourse.degree = degree;
                    context.studentCourses.Update(studentCourse);
                }

            }

            context.SaveChanges();



            return RedirectToAction("Courses", new { id = deptID });
        }
    }
}