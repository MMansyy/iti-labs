using AutoMapper;
using Lab_2.DTOs.Student;
using Lab_2.Models;
using Lab_2.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //private readonly IEntities<Student> _students;
        private readonly IMapper _map;
        private readonly UnitOfWork _unit;

        public StudentController(
            //IEntities<Student> studnet,
            IMapper map, UnitOfWork unit)
        {
            //_students = studnet;
            _map = map;
            _unit = unit;
        }

        [HttpGet]
        public ActionResult GetAll([FromQuery] string? searchWord, [FromQuery] int pageNum = 1, [FromQuery] int pageLimit = 10)
        {
            var students = _unit.StudentRepo.GetAll(pageNum, pageLimit, s => searchWord == null || s.StFname.Contains(searchWord), "Dept,StSuperNavigation");

            if (!students.Any()) return NotFound();

            //var studentDTOs = new List<DisplayStudentDTO>();
            //foreach (var student in students)
            //{
            //    var StDTO = new DisplayStudentDTO()
            //    {
            //        St_Id = student.StId,
            //        St_Fname = student.StFname + ' ' + student.StLname,
            //        Dept_Name = student.Dept?.DeptName,
            //        St_Address = student.StAddress,
            //        Supervisor_Name = student.StSuperNavigation?.StFname
            //    };
            //    studentDTOs.Add(StDTO);
            //}
            var studentDTOs = _map.Map<List<DisplayStudentDTO>>(students);

            return Ok(new
            {
                pageNum,
                pageLimit,
                totalItems = students.Count(),
                studentDTOs
            });
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        {
            var student = _unit.StudentRepo.GetAll(1, 10, s => s.StId == id, "Dept,StSuperNavigation").FirstOrDefault();

            if (student == null) return NotFound();

            //var StDTO = new DisplayStudentDTO()
            //{
            //    St_Id = id,
            //    St_Fname = student.StFname + ' ' + student.StLname,
            //    Dept_Name = student.Dept.DeptName,
            //    St_Address = student.StAddress,
            //    Supervisor_Name = student.StSuperNavigation.StFname
            //};
            var StDTO = _map.Map<DisplayStudentDTO>(student);
            return Ok(StDTO);
        }

        [HttpPost]
        public ActionResult Create(CreateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var student = new Student
            //{
            //    StId = studentDTO.StudentId,
            //    DeptId = studentDTO.DeptId,
            //    StAddress = studentDTO.StAddress,
            //    StAge = studentDTO.StAge,
            //    StFname = studentDTO.StFname,
            //    StLname = studentDTO.StLname,
            //    StSuper = studentDTO.SuperviorId
            //};

            var student = _map.Map<Student>(studentDTO);

            _unit.StudentRepo.Add(student);
            _unit.Save();

            return CreatedAtAction(
                nameof(GetById),
                new { id = student.StId },
                studentDTO
            );
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult Update(int id, UpdateStudentDTO updatedStudent)
        {
            var student = _unit.StudentRepo.GetById(id);

            if (student == null)
                return NotFound();

            student.StFname = updatedStudent.StFname ?? student.StFname;
            student.StLname = updatedStudent.StLname ?? student.StLname;
            student.StAddress = updatedStudent.StAddress ?? student.StAddress;
            student.StAge = updatedStudent.StAge ?? student.StAge;
            student.StSuper = updatedStudent.SuperviorId ?? student.StSuper;
            student.DeptId = updatedStudent.DeptId ?? student.DeptId;

            _unit.StudentRepo.Update(student);
            _unit.Save();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(int id)
        {
            var student = _unit.StudentRepo.GetById(id);
            if (student == null)
                return NotFound();
            _unit.StudentRepo.Delete(id);
            _unit.StudentRepo.Save();
            return NoContent();
        }


        [HttpPost]
        [Route("login/")]
        public ActionResult Login(string username, string password)
        {
            #region claims
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {

                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                claims.Add(new Claim(ClaimTypes.Gender, "Male"));
                claims.Add(new Claim(ClaimTypes.MobilePhone, "01211984470"));
            #endregion

                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("This is my key hello everybody nice to see you"));

                var signCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                         claims: claims,
                         expires: DateTime.Now.AddHours(2),
                         signingCredentials: signCred
                    );

                var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(stringToken);
            }

            return BadRequest();
        }

    }
}
