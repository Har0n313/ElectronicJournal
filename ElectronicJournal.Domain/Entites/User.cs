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
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public UserRoleEnum Role { get; set; }

    }
}
