using ElectronicJournal.Application.Dtos.ScheduleDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class ScheduleService : IScheduleService
    {
        public readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<ScheduleResponse> CreateAsync(CreateScheduleRequest request, CancellationToken token)
        {
            var schedule = new Schedule
            {
                SchoolClassId = request.SchoolClassId,
                SubjectId = request.SubjectId,
                Date = request.Date,
                Time = request.Time
            };

            await _scheduleRepository.AddAsync(schedule, token);
            await _scheduleRepository.SaveChangesAsync();

            return new ScheduleResponse(schedule.Id, schedule.SchoolClassId, schedule.SubjectId, schedule.Date, schedule.Time);
        }
        public async Task<ScheduleResponse> UpdateAsync(UpdateScheduleRequest request, CancellationToken token)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleId, token);

            if (schedule == null)
                throw new Exception("Schedule not found");

            schedule.SchoolClassId = request.SchoolClassId;
            schedule.SubjectId = request.SubjectId;
            schedule.Date = request.Date;
            schedule.Time = request.Time;

            await _scheduleRepository.UpdateAsync(schedule, token);
            await _scheduleRepository.SaveChangesAsync();

            return new ScheduleResponse(schedule.Id, schedule.SchoolClassId, schedule.SubjectId, schedule.Date, schedule.Time);

        }

        public async Task<ScheduleResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(id, token);

            if (schedule == null)
                throw new Exception("Schedule not found");

            return new ScheduleResponse(schedule.Id, schedule.SchoolClassId, schedule.SubjectId, schedule.Date, schedule.Time);
        }

        public async Task<ICollection<ScheduleResponse>> GetOdataAsync(SearchScheduleRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<Schedule>();
            var queryable = await _scheduleRepository.GetQueryableAsync(options, token);
            var results = queryable.ToList();

            return results.Select(a =>
                new ScheduleResponse(a.Id, a.SchoolClassId, a.SubjectId, a.Date, a.Time)).ToList();
        }
        public async Task<bool> DeleteAsync(Guid scheduleId, CancellationToken token)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId, token);

            if (schedule == null) 
                return false;

            await _scheduleRepository.DeleteAsync(schedule, token);
            await _scheduleRepository.SaveChangesAsync();
            return true;
        }


    }
}
