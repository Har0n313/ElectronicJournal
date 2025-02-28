using ElectronicJournal.Application.Dtos.AttendanceDtos;

namespace ElectronicJournal.Application.Interfaces.Services;

public interface IAttendanceService
{
    Task<AttendanceResponse> CreateAsync(CreateAttendanceRequest request, CancellationToken token);
    Task<AttendanceResponse> UpdateAsync(UpdateAttendanceRequest request, CancellationToken token);
    Task<AttendanceResponse> GetByIdAsync(Guid id, CancellationToken token);
    Task<ICollection<AttendanceResponse>> GetOdataAsync(SearchAttendanceRequest request, CancellationToken token);
    Task<bool> DeleteAsync(Guid attendanceId, CancellationToken token);
}