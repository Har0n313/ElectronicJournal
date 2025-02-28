using ElectronicJournal.Application.Dtos.ScheduleDtos;

namespace ElectronicJournal.Application.Interfaces.Services;

public interface IScheduleService
{
    Task<ScheduleResponse> CreateAsync(CreateScheduleRequest request, CancellationToken token);
    Task<ScheduleResponse> UpdateAsync(UpdateScheduleRequest request, CancellationToken token);
    Task<ScheduleResponse> GetByIdAsync(Guid id, CancellationToken token);
    Task<ICollection<ScheduleResponse>> GetOdataAsync(SearchScheduleRequest request, CancellationToken token);
    Task<bool> DeleteAsync(Guid scheduleId, CancellationToken token);
}