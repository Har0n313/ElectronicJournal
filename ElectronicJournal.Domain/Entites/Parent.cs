namespace ElectronicJournal.Domain.Entites;

/// <summary>
/// Родитель
/// </summary>
public class Parent : User
{
    public ICollection<Student>? Students { get; set; } = new List<Student>();
}