namespace MyApp.Application.DTOs;

// Represents student data returned from the application layer.
public sealed class StudentDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public int Age { get; init; }
}
