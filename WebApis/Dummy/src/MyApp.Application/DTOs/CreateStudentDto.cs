namespace MyApp.Application.DTOs;

// Represents the input model used to create a student.
public sealed class CreateStudentDto
{
    public required string Name { get; init; }

    public int Age { get; init; }
}
