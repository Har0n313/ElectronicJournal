using ElectronicJournal.Application.Dtos.ParentDtos;

namespace ElectronicJournal.Application.Interfaces.Services
{
    public interface IParentService
    {
        Task<ParentResponse> CreateAsync(CreateParentRequest request, CancellationToken token);
        Task<ParentResponse> UpdateAsync(UpdateParentRequest request, CancellationToken token);
        Task<ParentResponse> GetByIdAsync(Guid id, CancellationToken token);
        Task<ICollection<ParentResponse>> GetOdataAsync(SearchParentRequest request, CancellationToken token);
        Task<bool> DeleteAsync(Guid parentId, CancellationToken token);
    }
}
