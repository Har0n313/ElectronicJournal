using ElectronicJournal.Application.Dtos.TeacherDtos;

namespace ElectronicJournal.Application.Interfaces.Services
{
    public interface ITeacherService
    {
        Task<TeacherResponse> CreateAsync(CreateTeacherRequest request, CancellationToken token);
        Task<TeacherResponse> UpdateAsync(UpdateTeacherRequest request, CancellationToken token);
        Task<TeacherResponse> GetByIdAsync(Guid id, CancellationToken token);
        Task<ICollection<TeacherResponse>> GetOdataAsync(SearchTeacherRequest request, CancellationToken token);
        Task<bool> DeleteAsync(Guid teacherId, CancellationToken token);
    }
}
