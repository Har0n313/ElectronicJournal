using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.Application.Dtos.TeacherDtos
{
    public sealed record UpdateTeacherRequest(Guid TeacherId, string FirstName, string LastName, string? MiddleName,DateTime DateOfBith, string AcademicDegree, string? Description, Guid SchoolId);
}
