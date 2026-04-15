using Lab_1.Models;
using Lab_1.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly ICourseRepo _courseRepo;

        public CoursesController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public IActionResult get()
        {
            var courses = _courseRepo.GetAll();

            if (courses.Any())
            {
                return Ok(courses);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("getById/{id}")]
        public IActionResult getById(int id)
        {
            var course = _courseRepo.GetById(id);

            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var course = _courseRepo.GetByName(name);

            if (course == null) return NotFound();

            return Ok(course);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult deleteCourse(int id)
        {
            var course = _courseRepo.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            _courseRepo.Delete(id);
            _courseRepo.Save();

            return Ok(_courseRepo.GetAll());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult put(int id, Course course)
        {
            if (course == null) return NotFound();

            if (course.ID != id) return BadRequest();

            var crs = _courseRepo.GetById(id);

            if (crs == null) return NotFound();

            _courseRepo.Update(course);
            _courseRepo.Save();

            return NoContent();

        }

        [HttpPost]
        public IActionResult post(Course course)
        {
            if (course == null) return BadRequest();

            if (ModelState.IsValid)
            {
                _courseRepo.Add(course);
                _courseRepo.Save();
                return CreatedAtAction(nameof(getById), new { id = course.ID }, course);
            }

            return BadRequest();
        }


    }
}
