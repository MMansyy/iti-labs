using MyApp.Application.DTOs;

namespace MyApp.Application.Abstractions;

// Exposes student use cases to the API layer.
public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAllStudents();

    Task<StudentDto?> GetStudentById(int id);

    Task<StudentDto> CreateStudent(CreateStudentDto createStudentDto);
}
