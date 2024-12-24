using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Dtos.AuthDtos
{
    public sealed record RegisterRequest(string Email, string Password, FullName FullName, UserRoleEnum Role);
}
