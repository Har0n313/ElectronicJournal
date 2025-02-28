using AutoMapper;
using ElectronicJournal.Application.Dtos.ScheduleDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services;

public class ScheduleService : IScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;
    private readonly IMapper _mapper;

    public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper)
    {
        _scheduleRepository = scheduleRepository;
        _mapper = mapper;
    }

    public async Task<ScheduleResponse> CreateAsync(CreateScheduleRequest request, CancellationToken token)
    {
        var schedule = _mapper.Map<Schedule>(request);

        var createSchedule = _scheduleRepository.AddAsync(schedule, token);
        await _scheduleRepository.SaveChangesAsync();

        var response = _mapper.Map<ScheduleResponse>(createSchedule);

        return response;
    }

    public async Task<ScheduleResponse> UpdateAsync(UpdateScheduleRequest request, CancellationToken token)
    {
        var schedule = await _scheduleRepository.GetByIdAsync(request.ScheduleId, token);

        if (schedule == null)
            throw new Exception("Schedule not found");

        _mapper.Map(request, schedule);

        await _scheduleRepository.UpdateAsync(schedule, token);
        await _scheduleRepository.SaveChangesAsync();

        var response = _mapper.Map<ScheduleResponse>(schedule);

        return response;
    }

    public async Task<ScheduleResponse> GetByIdAsync(Guid id, CancellationToken token)
    {
        var schedule = await _scheduleRepository.GetByIdAsync(id, token);

        if (schedule == null)
            throw new Exception("Schedule not found");

        var response = _mapper.Map<ScheduleResponse>(schedule);

        return response;
    }

    public async Task<ICollection<ScheduleResponse>> GetOdataAsync(SearchScheduleRequest request,
        CancellationToken token)
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