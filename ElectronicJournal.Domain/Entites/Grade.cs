
namespace ElectronicJournal.Domain.Entites
{
    /// <summary>
    /// Оценка
    /// </summary>
    public class Grade : BaseEntity
    {
        public Guid StudentId {  get; set; }
        public Student Student { get; set; }
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public DateTime Date {  get; set; }
        public int Value { get; set; }
        public string? Comment {  get; set; }
    }
}
