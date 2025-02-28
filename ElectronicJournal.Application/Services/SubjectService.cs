using AutoMapper;
using ElectronicJournal.Application.Dtos.SubjectDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IMapper _mapper;

    public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<SubjectResponse> CreateAsync(CreateSubjectRequest request, CancellationToken token)
    {
        var subject = _mapper.Map<Subject>(request);

        var createSubject = _subjectRepository.AddAsync(subject, token);
        await _subjectRepository.SaveChangesAsync();

        var response = _mapper.Map<SubjectResponse>(createSubject);

        return response;
    }

    public async Task<SubjectResponse> UpdateAsync(UpdateSubjectRequest request, CancellationToken token)
    {
        var subject = await _subjectRepository.GetByIdAsync(request.SubjectId, token);

        if (subject == null)
            throw new Exception("Subject not found");

        _mapper.Map(request, subject);

        await _subjectRepository.UpdateAsync(subject, token);
        await _subjectRepository.SaveChangesAsync();

        var response = _mapper.Map<SubjectResponse>(subject);

        return response;
    }

    public async Task<SubjectResponse> GetByIdAsync(Guid id, CancellationToken token)
    {
        var subject = await _subjectRepository.GetByIdAsync(id, token);

        if (subject == null)
            throw new Exception("Subject not found");

        var response = _mapper.Map<SubjectResponse>(subject);

        return response;
    }

    public async Task<ICollection<SubjectResponse>> GetOdataAsync(SearchSubjectRequest request, CancellationToken token)
    {
        var options = request.ToODataQueryOptions<Subject>();
        var queryable = await _subjectRepository.GetQueryableAsync(options, token);
        var results = queryable.ToList();

        return results.Select(a =>
            new SubjectResponse(a.Id, a.Name, a.TeacherId)).ToList();
    }

    public async Task<bool> DeleteAsync(Guid subjectId, CancellationToken token)
    {
        var subject = await _subjectRepository.GetByIdAsync(subjectId, token);

        if (subject == null)
            return false;

        await _subjectRepository.DeleteAsync(subject, token);
        await _subjectRepository.SaveChangesAsync();

        return true;
    }
}