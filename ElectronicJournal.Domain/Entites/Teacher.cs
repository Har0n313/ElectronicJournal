namespace ElectronicJournal.Domain.Entites;

/// <summary>
/// Учитель
/// </summary>
public class Teacher : User
{
    public string AcademicDegree { get; set; }
    public string Description { get; set; }
    public Guid SchollId { get; set; }
    public School School { get; set; }
    public ICollection<Subject> Subjects { get; set; }
    public ICollection<SchoolClass> SchoolClasses { get; set; }
}