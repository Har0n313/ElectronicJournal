
namespace ElectronicJournal.Domain.Entites
{
    /// <summary>
    /// Предмет
    /// </summary>
    public class Subject : BaseEntity 
    {
        public string Name { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public ICollection<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
    }
}
