using AutoMapper;
using ElectronicJournal.Application.Dtos.GradeDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(IGradeRepository gradeRepository, IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
        }

        public async Task<GradeResponse> CreateAsync(CreateGradeRequest request, CancellationToken token)
        {
            var grade = _mapper.Map<Grade>(request);

            var createGrade = _gradeRepository.AddAsync(grade, token);
            await _gradeRepository.SaveChangesAsync();
            
            var response = _mapper.Map<GradeResponse>(createGrade);

            return response;
        }
        public async Task<GradeResponse> UpdateAsync(UpdateGradeRequest request, CancellationToken token)
        {
            var grade = await _gradeRepository.GetByIdAsync(request.GradeId, token);

            if (grade == null)
                throw new Exception("Grade not found");

            _mapper.Map(request, grade);

            await _gradeRepository.UpdateAsync(grade, token);
            await _gradeRepository.SaveChangesAsync();
            
            var response = _mapper.Map<GradeResponse>(grade);

            return response;
        }

        public async Task<GradeResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var grade = await _gradeRepository.GetByIdAsync(id, token);

            if (grade == null)
                throw new Exception("Grade not fount");
            
            var response = _mapper.Map<GradeResponse>(grade);

            return response;
        }

        public async Task<ICollection<GradeResponse>> GetOdataAsync(SearchGradeRequest request, CancellationToken token)
        {
            var option = request.ToODataQueryOptions<Grade>();
            var queryable = await _gradeRepository.GetQueryableAsync(option, token);
            var result = queryable.ToList();

            return result.Select(a => 
            new GradeResponse(a.Id, a.StudentId, a.SubjectId,a.Date, a.Value, a.Comment)).ToList();
        }

        public async Task<bool> DeleteAsync(Guid gradeId, CancellationToken token)
        {
            var grade = await _gradeRepository.GetByIdAsync(gradeId, token);

            if(grade == null)
                return false;

            await _gradeRepository.DeleteAsync(grade, token);
            await _gradeRepository.SaveChangesAsync();

            return true;
        }
    }
}
