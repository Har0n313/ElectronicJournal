using ElectronicJournal.Application.Dtos.SchoolClassDtos;

namespace ElectronicJournal.Application.Interfaces.Services
{
    public interface ISchoolClassService
    {
        Task<SchoolClassResponse> CreateAsync(CreateSchoolClassRequest request, CancellationToken token);
        Task<SchoolClassResponse> UpdateAsync(UpdateSchoolClassRequest request, CancellationToken token);
        Task<SchoolClassResponse> GetByIdAsync(Guid id, CancellationToken token);
        Task<ICollection<SchoolClassResponse>> GetOdataAsync(SearchSchoolClassRequest request, CancellationToken token);
        Task<bool> DeleteAsync(Guid schoolClassId, CancellationToken token);
    }
}
