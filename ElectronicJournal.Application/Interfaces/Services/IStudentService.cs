using ElectronicJournal.Application.Dtos.StudentDtos;

namespace ElectronicJournal.Application.Interfaces.Services
{
    public interface IStudentService
    {
        Task<StudentResponse> CreateAsync(CreateStudentRequest request, CancellationToken token);
        Task<StudentResponse> UpdateAsync(UpdateStudentRequest request, CancellationToken token);
        Task<StudentResponse> GetByIdAsync(Guid id, CancellationToken token);
        Task<ICollection<StudentResponse>> GetOdataAsync(SearchStudentRequest request, CancellationToken token);
        Task<bool> DeleteAsync(Guid studentId, CancellationToken token);
    }
}
