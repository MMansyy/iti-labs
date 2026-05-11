namespace MyApp.Domain.Entities;

// Represents a student in the domain model.
public class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
}
