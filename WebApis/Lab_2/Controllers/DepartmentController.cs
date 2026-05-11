using AutoMapper;
using Lab_2.DTOs.Department;
using Lab_2.Models;
using Lab_2.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IEntities<Department> _departments;
        private readonly IMapper _mapper;

        public DepartmentController(IEntities<Department> departments, IMapper mapper)
        {
            _departments = departments;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var departments = _departments.GetAll(1, 10, null, "Students");

            if (!departments.Any()) return NotFound();

            var departmentsDTOs = _mapper.Map<List<DisplayDepartmentDTO>>(departments);

            return Ok(departmentsDTOs);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var department = _departments.GetAll(1, 10, d => d.DeptId == id, "Students").FirstOrDefault();

            if (department == null) return NotFound();

            var departmentDTO = _mapper.Map<DisplayDepartmentDTO>(department);
            return Ok(departmentDTO);
        }

        [HttpPost]
        public ActionResult Create(CreateDepartmentDTO departmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var department = _mapper.Map<Department>(departmentDTO);

            _departments.Add(department);
            _departments.Save();

            var displayDepartmentDTO = _mapper.Map<DisplayDepartmentDTO>(department);

            return CreatedAtAction(
                nameof(GetById),
                new { id = department.DeptId },
                displayDepartmentDTO
            );
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, UpdateDepartmentDTO updatedDepartment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var department = _departments.GetById(id);

            if (department == null)
                return NotFound();

            _mapper.Map(updatedDepartment, department);

            _departments.Update(department);
            _departments.Save();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var department = _departments.GetById(id);
            if (department == null)
                return NotFound();

            _departments.Delete(id);
            _departments.Save();
            return NoContent();
        }
    }
}
