namespace ElectronicJournal.Domain.Entites;

/// <summary>
/// Класс
/// </summary>
public class SchoolClass : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public Guid SchoolId { get; set; }
    public School School { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}