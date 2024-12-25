using AutoMapper;
using ElectronicJournal.Application.Dtos.StudentDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.Primitives.Enums;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> CreateAsync(CreateStudentRequest request, CancellationToken token)
        {
            var isEmailTaken = await _registrationRepository.IsEmailTakenAsync(request.Email, token);
            if (isEmailTaken)
            {
                throw new InvalidOperationException("A user with this email already exists.");
            }

            var hashpassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var student = _mapper.Map<Student>(request);

            var createStudent = _studentRepository.AddAsync(student, token);
            await _studentRepository.SaveChangesAsync();

            var response = _mapper.Map<StudentResponse>(createStudent);   

            return new StudentResponse(student.Id, student.FullName, student.ShoolClassId, student?.Description);
        }

        public async Task<StudentResponse> UpdateAsync(UpdateStudentRequest request, CancellationToken token)
        {
            var student = await _studentRepository.GetByIdAsync(request.StudentId, token);

            if (student == null)
                throw new Exception("Student not found");

            _mapper.Map(request, student);

            await _studentRepository.UpdateAsync(student,token);
            await _studentRepository.SaveChangesAsync();

            var response = _mapper.Map<StudentResponse>(student);
            return response;
        }

        public async Task<StudentResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var student = await _studentRepository.GetByIdAsync(id, token);

            if (student == null)
                throw new Exception("Student not found");

            var response = _mapper.Map<StudentResponse>(student);

            return response;
        }

        public async Task<ICollection<StudentResponse>> GetOdataAsync(SearchStudentRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<Student>();
            var queryable = await _studentRepository.GetQueryableAsync(options, token);
            var results = queryable.ToList();

            return results.Select(a =>
                new StudentResponse(a.Id, a.FullName, a.ShoolClassId, a.Description)).ToList();
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
