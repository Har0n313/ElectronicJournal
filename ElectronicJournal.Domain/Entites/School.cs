
namespace ElectronicJournal.Domain.Entites
{
    /// <summary>
    /// Школа
    /// </summary>
    public class School : BaseEntity
    {
        public string Name { get; set; }
        public string Address {  get; set; }
        public string Description { get; set; }
        public ICollection<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
        public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
