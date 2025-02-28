using ElectronicJournal.Application.Dtos.SchoolDtos;

namespace ElectronicJournal.Application.Interfaces.Services;

public interface ISchoolService
{
    Task<SchoolResponse> CreateAsync(CreateSchoolRequest request, CancellationToken token);
    Task<SchoolResponse> UpdateAsync(UpdateSchoolRequest request, CancellationToken token);
    Task<SchoolResponse> GetByIdAsync(Guid id, CancellationToken token);
    Task<ICollection<SchoolResponse>> GetOdataAsync(SearchSchoolRequest request, CancellationToken token);
    Task<bool> DeleteAsync(Guid schoolId, CancellationToken token);
}