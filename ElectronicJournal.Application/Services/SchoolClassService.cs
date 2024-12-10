using ElectronicJournal.Application.Dtos.SchoolClassDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class SchoolClassService : ISchoolClassService
    {
        public readonly ISchoolClassRepository _schoolClassRepository;

        public SchoolClassService(ISchoolClassRepository schoolClassRepository)
        {
            _schoolClassRepository = schoolClassRepository;
        }

        public async Task<SchoolClassResponse> CreateAsync(CreateSchoolClassRequest request, CancellationToken token)
        {
            var schoolClass = new SchoolClass
            {
                Name = request.Name,
                Description = request.Description,
                TeacherId = request.TeacherId,
                SchoolId = request.SchoolId,
            };

            await _schoolClassRepository.AddAsync(schoolClass, token);
            await _schoolClassRepository.SaveChangesAsync();

            return new SchoolClassResponse(schoolClass.Id, schoolClass.Name, schoolClass.Description, schoolClass.TeacherId, schoolClass.SchoolId);
        }

        public async Task<SchoolClassResponse> UpdateAsync(UpdateSchoolClassRequest request, CancellationToken token)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(request.SchoolClassId, token);

            if (schoolClass == null)
                throw new Exception("SchoolClass not found");

            schoolClass.Name = request.Name;
            schoolClass.Description = request.Description;
            schoolClass.TeacherId = request.TeacherId;
            schoolClass.SchoolId = request.SchoolId;

            await _schoolClassRepository.UpdateAsync(schoolClass, token);
            await _schoolClassRepository.SaveChangesAsync();

            return new SchoolClassResponse(schoolClass.Id, schoolClass.Name, schoolClass.Description, schoolClass.TeacherId, schoolClass.SchoolId);
        }

        public async Task<SchoolClassResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(id, token);

            if (schoolClass == null)
                throw new Exception("SchoolClass not found");

            return new SchoolClassResponse(schoolClass.Id, schoolClass.Name, schoolClass.Description, schoolClass.TeacherId, schoolClass.SchoolId);
        }

        public async Task<ICollection<SchoolClassResponse>> GetOdataAsync(SearchSchoolClassRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<SchoolClass>();
            var queryable = await _schoolClassRepository.GetQueryableAsync(options, token);
            var result = queryable.ToList();

            return result.Select(a =>
                new SchoolClassResponse(a.Id, a.Name, a.Description, a.TeacherId, a.SchoolId)).ToList();
        }

        public async Task<bool> DeleteAsync(Guid schoolClassId, CancellationToken token)
        {
            var schoolClass = await _schoolClassRepository.GetByIdAsync(schoolClassId, token);

            if (schoolClass == null)
                return false;

            await _schoolClassRepository.DeleteAsync(schoolClass, token);
            await _schoolClassRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
