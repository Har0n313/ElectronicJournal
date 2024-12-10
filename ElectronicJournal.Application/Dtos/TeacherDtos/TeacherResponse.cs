﻿
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Dtos.TeacherDtos
{
    public sealed record TeacherResponse(Guid TeacherId, FullName FullName, DateTime DateOfBith, Guid SchoolId, string AcademicDegree, string? Description);
}