namespace ElectronicJournal.Domain.Entites;

/// <summary>
/// Ученик
/// </summary>
public class Student : User
{
    public string? Description { get; set; }
    public Guid ShoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; }
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    public ICollection<Parent> Parents { get; set; } = new List<Parent>();
}