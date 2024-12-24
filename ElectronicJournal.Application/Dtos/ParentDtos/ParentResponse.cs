
using ElectronicJournal.Application.Dtos.StudentDtos;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Dtos.ParentDtos
{
    public sealed record ParentResponse(Guid ParentId, FullName FullName, DateTime? dateofBith);
}
