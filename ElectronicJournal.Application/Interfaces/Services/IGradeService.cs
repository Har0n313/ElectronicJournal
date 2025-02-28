using ElectronicJournal.Application.Dtos.GradeDtos;

namespace ElectronicJournal.Application.Interfaces.Services;

public interface IGradeService
{
    Task<GradeResponse> CreateAsync(CreateGradeRequest request, CancellationToken token);
    Task<GradeResponse> UpdateAsync(UpdateGradeRequest request, CancellationToken token);
    Task<GradeResponse> GetByIdAsync(Guid id, CancellationToken token);
    Task<ICollection<GradeResponse>> GetOdataAsync(SearchGradeRequest request, CancellationToken token);
    Task<bool> DeleteAsync(Guid gradeId, CancellationToken token);
}