using ElectronicJournal.Application.Dtos.SubjectDtos;

namespace ElectronicJournal.Application.Interfaces.Services;

public interface ISubjectService
{
    Task<SubjectResponse> CreateAsync(CreateSubjectRequest request, CancellationToken token);
    Task<SubjectResponse> UpdateAsync(UpdateSubjectRequest request, CancellationToken token);
    Task<SubjectResponse> GetByIdAsync(Guid id, CancellationToken token);
    Task<ICollection<SubjectResponse>> GetOdataAsync(SearchSubjectRequest request, CancellationToken token);
    Task<bool> DeleteAsync(Guid subjectId, CancellationToken token);
}