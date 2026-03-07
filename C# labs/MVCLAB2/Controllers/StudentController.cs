using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCLAB2.Models;
using MVCLAB2.Repos;
using System.Linq;

namespace MVCLAB2.Controllers
{

    [Authorize(Roles = "Admin")]

    public class StudentController : Controller
    {
        IEntities<Student> studentRepo;
        IEntities<Department> departmentRepo;


        public StudentController(IEntities<Student> studentRepo, IEntities<Department> departmentRepo)
        {
            this.studentRepo = studentRepo;
            this.departmentRepo = departmentRepo;
        }

        public IActionResult Index()
        {
            var students = studentRepo.GetAll();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var departments = departmentRepo.GetAll().ToList();
            ViewBag.deptId = new SelectList(departments, "deptID", "deptName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Add(std);
                return RedirectToAction("Index");
            }
            var departments = departmentRepo.GetAll().ToList();
            ViewBag.deptId = new SelectList(departments, "deptID", "deptName");
            return View(std);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            var departments = departmentRepo.GetAll().ToList();
            ViewBag.deptId = new SelectList(departments, "deptID", "deptName", student.deptId);
            return View(student);

        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                studentRepo.Update(std);
                return RedirectToAction("Index");
            }
            var departments = departmentRepo.GetAll().ToList();
            ViewBag.deptId = new SelectList(departments, "deptID", "deptName", std.deptId);
            return View(std);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            studentRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var student = studentRepo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);

        }
    }
}
