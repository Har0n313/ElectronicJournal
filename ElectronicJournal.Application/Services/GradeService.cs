using ElectronicJournal.Application.Dtos.GradeDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class GradeService : IGradeService
    {
        public readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public async Task<GradeResponse> CreateAsync(CreateGradeRequest request, CancellationToken token)
        {
            var grade = new Grade
            {
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
                Date = request.Date,
                Value = request.Value,
                Comment = request.Comment,
            };
            await _gradeRepository.AddAsync(grade, token);
            await _gradeRepository.SaveChangesAsync();

            return new GradeResponse(grade.Id, grade.StudentId, grade.SubjectId, grade.Date, grade.Value, grade?.Comment);
        }
        public async Task<GradeResponse> UpdateAsync(UpdateGradeRequest request, CancellationToken token)
        {
            var grade = await _gradeRepository.GetByIdAsync(request.GradeId, token);

            if (grade == null)
                throw new Exception("Grade not found");

            grade.StudentId = request.StudentId;
            grade.SubjectId = request.SubjectId;
            grade.Date = request.Date;
            grade.Value = request.Value;
            grade.Comment = request.Comment;
            
            await _gradeRepository.UpdateAsync(grade,token);
            await _gradeRepository.SaveChangesAsync();

            return new GradeResponse(grade.Id, grade.StudentId, grade.SubjectId, grade.Date, grade.Value, grade?.Comment);
        }

        public async Task<GradeResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var grade = await _gradeRepository.GetByIdAsync(id, token);

            if (grade == null)
                throw new Exception("Grade not fount");

            return new GradeResponse(grade.Id, grade.StudentId, grade.SubjectId, grade.Date, grade.Value, grade?.Comment);
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
