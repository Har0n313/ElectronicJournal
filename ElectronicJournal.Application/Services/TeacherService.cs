using ElectronicJournal.Application.Dtos.TeacherDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Services
{
    public class TeacherService : ITeacherService
    {
        public readonly ITeacherRepository _teacherRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<TeacherResponse> CreateAsync(CreateTeacherRequest request, CancellationToken token)
        {
            var isEmailTaken = await _registrationRepository.IsEmailTakenAsync(request.Email, token);
            if (isEmailTaken)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }
            var hashpassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var teacher = new Teacher
            {
                FullName = new FullName(request.FirstName, request.LastName, request?.MiddleName),
                AcademicDegree = request.AcademicDegree,
                Description = request.Description,
                SchollId = request.SchoolId,
                Email = request.Email,
                PasswordHash = hashpassword,
                Role = UserRoleEnum.Teacher
            };

            await _teacherRepository.AddAsync(teacher, token);
            await _teacherRepository.SaveChangesAsync();

            return new TeacherResponse(teacher.Id, teacher.FullName, teacher.SchollId, teacher.AcademicDegree, teacher.Description);
        }

        public async Task<TeacherResponse> UpdateAsync(UpdateTeacherRequest request, CancellationToken token)
        {
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId, token);

            if (teacher == null)
                throw new Exception("Teacher not found");

            teacher.FullName = new FullName(request.FirstName, request.LastName, request?.MiddleName);
            teacher.AcademicDegree = request.AcademicDegree;
            teacher.Description = request.Description;
            teacher.SchollId = request.SchoolId;

            await _teacherRepository.UpdateAsync(teacher, token);
            await _teacherRepository.SaveChangesAsync();

            return new TeacherResponse(teacher.Id, teacher.FullName, teacher.SchollId, teacher.AcademicDegree, teacher.Description);
        }

        public async Task<TeacherResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id, token);

            if (teacher == null)
                throw new Exception("Teacher not found");

            return new TeacherResponse(teacher.Id, teacher.FullName, teacher.SchollId, teacher.AcademicDegree, teacher.Description);
        }

        public async Task<ICollection<TeacherResponse>> GetOdataAsync(SearchTeacherRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<Teacher>();
            var queryable = await _teacherRepository.GetQueryableAsync(options, token);
            var results = queryable.ToList();

            return results.Select(a =>
                new TeacherResponse(a.Id, a.FullName, a.SchollId, a.AcademicDegree, a?.Description)).ToList();
        }

        public async Task<bool> DeleteAsync(Guid teacherId, CancellationToken token)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId, token);

            if (teacher == null)
                return false;

            await _teacherRepository.DeleteAsync(teacher, token);
            await _teacherRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
