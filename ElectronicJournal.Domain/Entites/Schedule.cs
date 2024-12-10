
namespace ElectronicJournal.Domain.Entites
{
    /// <summary>
    /// Расписание
    /// </summary>
    public class Schedule : BaseEntity
    {   
        public Guid SchoolClassId { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date {  get; set; }
        public TimeSpan Time {  get; set; }
    }
}
