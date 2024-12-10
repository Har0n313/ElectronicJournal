using ElectronicJournal.Application.Dtos.SubjectDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class SubjectService : ISubjectService
    {
        public readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<SubjectResponse> CreateAsync(CreateSubjectRequest request, CancellationToken token)
        {
            var subject = new Subject
            {
                Name = request.Name,
                TeacherId = request.TeacherId,
            };

            await _subjectRepository.AddAsync(subject, token);

            return new SubjectResponse(subject.Id, subject.Name, subject.TeacherId);
        }

        public async Task<SubjectResponse> UpdateAsync(UpdateSubjectRequest request, CancellationToken token)
        {
            var subject = await _subjectRepository.GetByIdAsync(request.SubjectId, token);

            if (subject == null)
                throw new Exception("Subject not found");

            subject.Name = request.Name;
            subject.TeacherId = request.TeacherId;

            return new SubjectResponse(subject.Id, subject.Name, subject.TeacherId);
        }

        public async Task<SubjectResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var subject = await _subjectRepository.GetByIdAsync(id, token);

            if (subject == null)
                throw new Exception("Subject not found");

            return new SubjectResponse(subject.Id, subject.Name, subject.TeacherId);
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

            if ( subject == null )
                return false;

            await _subjectRepository.DeleteAsync(subject, token);
            await _subjectRepository.SaveChangesAsync();

            return true;
        }
    }
}
