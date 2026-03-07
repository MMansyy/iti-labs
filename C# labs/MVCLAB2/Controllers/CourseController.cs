using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCLAB2.Models;
using MVCLAB2.Repos;

namespace MVCLAB2.Controllers
{

    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        IEntities<Course> courseRepo;
        IEntities<Department> departmentRepo;


        public CourseController(IEntities<Course> courseRepo, IEntities<Department> departmentRepo)
        {
            this.courseRepo = courseRepo;
            this.departmentRepo = departmentRepo;
        }


        public IActionResult Index()
        {
            var courses = courseRepo.GetAll();
            return View(courses);
        }


        public IActionResult Details(int id)
        {
            var course = courseRepo.GetById(id);
            return View(course);
        }


        public IActionResult Create()
        {
            ViewBag.deptID = new SelectList(
                departmentRepo.GetAll(),
                "deptID",
                "deptName"
            );

            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Add(course);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.deptID = new SelectList(
                departmentRepo.GetAll(),
                "deptID",
                "deptName",
                course.deptID
            );

            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = courseRepo.GetById(id);

            ViewBag.deptID = new SelectList(
                departmentRepo.GetAll(),
                "deptID",
                "deptName",
                course.deptID
            );

            return View(course);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                courseRepo.Update(course);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.deptID = new SelectList(
                departmentRepo.GetAll(),
                "deptID",
                "deptName",
                course.deptID
            );

            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = courseRepo.GetById(id);
            return View(course);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            courseRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}