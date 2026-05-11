using Microsoft.AspNetCore.Mvc;
using MyApp.Application.DTOs;
using MyApp.Application.Services;

namespace MyApp.API.Controllers;

// Exposes student use cases over HTTP.
[ApiController]
[Route("api/[controller]")]
public sealed class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll(CancellationToken cancellationToken)
    {
        var students = await _studentService.GetAllStudents(cancellationToken);
        return Ok(students);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<StudentDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var student = await _studentService.GetStudentById(id, cancellationToken);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDto>> Create([FromBody] CreateStudentDto createStudentDto, CancellationToken cancellationToken)
    {
        var createdStudent = await _studentService.CreateStudent(createStudentDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = createdStudent.Id }, createdStudent);
    }
}
