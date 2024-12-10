using ElectronicJournal.Application.Dtos.StudentDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Services
{
    public class StudentService : IStudentService
    {
        public readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponse> CreateAsync(CreateStudentRequest request, CancellationToken token)
        {
            var student = new Student
            {
                FullName = new FullName(request.FirstName, request.LastName, request?.MiddleName),
                DateofBirth = request.DateofBith,
                Description = request.Description,
                ShoolClassId = request.SchoolClassId,
            };

            await _studentRepository.AddAsync(student, token);
            await _studentRepository.SaveChangesAsync();

            return new StudentResponse(student.Id, student.FullName, student.DateofBirth, student.ShoolClassId, student?.Description);
        }

        public async Task<StudentResponse> UpdateAsync(UpdateStudentRequest request, CancellationToken token)
        {
            var student = await _studentRepository.GetByIdAsync(request.StudentId, token);

            if (student == null)
                throw new Exception("Student not found");

            student.FullName = new FullName(request.FirstName,request.LastName, request?.MiddleName);
            student.DateofBirth = request.DateOfBith;
            student.Description = request.Description;
            student.ShoolClassId = request.SchoolClassId;

            await _studentRepository.UpdateAsync(student,token);
            await _studentRepository.SaveChangesAsync();

            return new StudentResponse(student.Id, student.FullName, student.DateofBirth, student.ShoolClassId, student?.Description);
        }

        public async Task<StudentResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var student = await _studentRepository.GetByIdAsync(id, token);

            if (student == null)
                throw new Exception("Student not found");

            return new StudentResponse(student.Id, student.FullName, student.DateofBirth, student.ShoolClassId, student?.Description);
        }

        public async Task<ICollection<StudentResponse>> GetOdataAsync(SearchStudentRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<Student>();
            var queryable = await _studentRepository.GetQueryableAsync(options, token);
            var results = queryable.ToList();

            return results.Select(a =>
                new StudentResponse(a.Id, a.FullName, a.DateofBirth, a.ShoolClassId, a.Description)).ToList();
        }

        public async Task<bool> DeleteAsync(Guid studentId, CancellationToken token)
        {
            var student = await _studentRepository.GetByIdAsync(studentId, token);

            if (student ==null)
                return false;

            await _studentRepository.DeleteAsync(student);
            await _studentRepository.SaveChangesAsync();

            return true;
        }
    }
}
