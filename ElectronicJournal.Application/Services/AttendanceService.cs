using ElectronicJournal.Application.Dtos.AttendanceDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(IAttendanceRepository repository)
        {
            _attendanceRepository = repository;
        }

        public async Task<AttendanceResponse> CreateAsync(CreateAttendanceRequest request, CancellationToken token)
        {
            var attendance = new Attendance
            {
                StudentId = request.StudentId,
                Date = request.Date,
                Status = request.Status
            };

            await _attendanceRepository.AddAsync(attendance, token);
            await _attendanceRepository.SaveChangesAsync();

            return new AttendanceResponse(attendance.Id, attendance.StudentId, attendance.Date, attendance.Status);
        }

        public async Task<AttendanceResponse> UpdateAsync(UpdateAttendanceRequest request, CancellationToken token)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(request.AttendanceId, token);

            if (attendance == null)
                throw new Exception("Attendance not found");

            attendance.StudentId = request.StudentId;
            attendance.Date = request.Date;
            attendance.Status = request.Status;

            await _attendanceRepository.UpdateAsync(attendance, token);
            await _attendanceRepository.SaveChangesAsync();

            return new AttendanceResponse(attendance.Id, attendance.StudentId, attendance.Date, attendance.Status);
        }

        public async Task<AttendanceResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(id, token);

            return new AttendanceResponse(attendance.Id, attendance.StudentId, attendance.Date, attendance.Status);
        }

        public async Task<ICollection<AttendanceResponse>> GetOdataAsync(SearchAttendanceRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<Attendance>(); 
            var queryable = await _attendanceRepository.GetQueryableAsync(options, token);
            var results = queryable.ToList();

            return results.Select(a =>
                new AttendanceResponse(a.Id, a.StudentId, a.Date, a.Status)).ToList();
        }

        public async Task<bool> DeleteAsync(Guid attendanceId, CancellationToken token)
        {
            var attendance = await _attendanceRepository.GetByIdAsync(attendanceId, token);

            if (attendance == null)
                return false;

            await _attendanceRepository.DeleteAsync(attendance, token);
            await _attendanceRepository.SaveChangesAsync();

            return true;
        }
    }
}
