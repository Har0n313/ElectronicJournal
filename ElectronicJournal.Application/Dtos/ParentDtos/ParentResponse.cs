using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Dtos.ParentDtos;

public sealed record ParentResponse(Guid ParentId, FullName FullName, string Email, ICollection<Student> Students);