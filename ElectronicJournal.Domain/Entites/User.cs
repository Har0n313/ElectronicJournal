using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Domain.Entites
{
    /// <summary>
    /// Базовай пользователь
    /// </summary>
    public class User : BaseEntity
    {
        public FullName FullName { get; set; }
        public DateTime DateofBirth { get; set; }
        public UserRoleEnum Role { get; set; }

    }
}
