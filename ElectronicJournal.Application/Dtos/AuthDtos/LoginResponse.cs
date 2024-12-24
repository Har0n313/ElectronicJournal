using ElectronicJournal.Domain.Primitives.Enums;

namespace ElectronicJournal.Application.Dtos.AuthDtos
{
    public sealed record LoginResponse( Guid Id , string Email, string Token, UserRoleEnum Role);
}
