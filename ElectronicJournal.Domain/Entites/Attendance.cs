namespace ElectronicJournal.Domain.Entites;

/// <summary>
/// Посещаемость
/// </summary>
public class Attendance : BaseEntity
{
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; } = false;
}