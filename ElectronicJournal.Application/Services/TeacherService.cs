using AutoMapper;
using ElectronicJournal.Application.Dtos.TeacherDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services;

public class TeacherService : ITeacherService
{
    public readonly ITeacherRepository _teacherRepository;
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IMapper _mapper;

    public TeacherService(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task<TeacherResponse> CreateAsync(CreateTeacherRequest request, CancellationToken token)
    {
        var isEmailTaken = await _registrationRepository.IsEmailTakenAsync(request.Email, token);
        if (isEmailTaken)
        {
            throw new InvalidOperationException("A user with this email already exists.");
        }

        var hashpassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var teacher = _mapper.Map<Teacher>(request);

        var createTeacher = _teacherRepository.AddAsync(teacher, token);
        await _teacherRepository.SaveChangesAsync();

        var response = _mapper.Map<TeacherResponse>(request);

        return response;
    }

    public async Task<TeacherResponse> UpdateAsync(UpdateTeacherRequest request, CancellationToken token)
    {
        var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId, token);

        if (teacher == null)
            throw new Exception("Teacher not found");

        _mapper.Map(request, teacher);

        await _teacherRepository.UpdateAsync(teacher, token);
        await _teacherRepository.SaveChangesAsync();

        var response = _mapper.Map<TeacherResponse>(teacher);

        return response;
    }

    public async Task<TeacherResponse> GetByIdAsync(Guid id, CancellationToken token)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id, token);

        if (teacher == null)
            throw new Exception("Teacher not found");

        var response = _mapper.Map<TeacherResponse>(teacher);

        return response;
    }

    public async void GetOdataAsync(SearchTeacherRequest request, CancellationToken token)
    {
        var options = request.ToODataQueryOptions<Teacher>();
        var queryable = await _teacherRepository.GetQueryableAsync(options, token);
        var results = queryable.ToList();
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