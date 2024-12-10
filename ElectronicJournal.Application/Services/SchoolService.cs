using ElectronicJournal.Application.Dtos.SchoolDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class SchoolService : ISchoolService
    {
        public readonly ISchoolRepository _schoolRepository;

        public SchoolService(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public async Task<SchoolResponse> CreateAsync(CreateSchoolRequest request, CancellationToken token)
        {
            var school = new School
            {
                Name = request.Name,
                Address = request.Address,
                Description = request.Description,
            };

            await _schoolRepository.AddAsync(school,token);
            await _schoolRepository.SaveChangesAsync();

            return new SchoolResponse(school.Id, school.Name, school.Address, school?.Description);
        }

        public async Task<SchoolResponse> UpdateAsync(UpdateSchoolRequest request, CancellationToken token)
        {
            var school = await _schoolRepository.GetByIdAsync(request.SchoolId, token);

            if (school == null)
                throw new Exception("School not found");

            school.Name = request.Name;
            school.Address = request.Address;
            school.Description = request.Description;

            await _schoolRepository.UpdateAsync(school,token);
            await _schoolRepository.SaveChangesAsync();

            return new SchoolResponse(school.Id, school.Name, school.Address, school?.Description);
        }

        public async Task<SchoolResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var school = await _schoolRepository.GetByIdAsync(id, token);

            if (school == null)
                throw new Exception("School not found");

            return new SchoolResponse(school.Id, school.Name, school.Address, school?.Description);
        }

        public async Task<ICollection<SchoolResponse>> GetOdataAsync(SearchSchoolRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<School>();
            var queryable = await _schoolRepository.GetQueryableAsync(options, token);
            var results = queryable.ToList();

            return results.Select(a =>
                new SchoolResponse(a.Id, a.Name, a.Address, a.Description)).ToList();
        }

        public async Task<bool> DeleteAsync(Guid schoolId, CancellationToken token)
        {
            var school = await _schoolRepository.GetByIdAsync(schoolId, token);

            if (school == null)
                return false;

            await _schoolRepository.DeleteAsync(school, token);
            await _schoolRepository.SaveChangesAsync();
            
            return true;
        }
    }
}
