using AutoMapper;
using ElectronicJournal.Application.Dtos.SchoolDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public SchoolService(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<SchoolResponse> CreateAsync(CreateSchoolRequest request, CancellationToken token)
        {
            var school = _mapper.Map<School>(request);

            var createdSchool = await _schoolRepository.AddAsync(school, token);
            await _schoolRepository.SaveChangesAsync();

            var response = _mapper.Map<SchoolResponse>(createdSchool);

            return response;
        }


        public async Task<SchoolResponse> UpdateAsync(UpdateSchoolRequest request, CancellationToken token)
        {
            var school = await _schoolRepository.GetByIdAsync(request.SchoolId, token);

            if (school == null)
                throw new Exception("School not found");

            _mapper.Map(request, school);

            await _schoolRepository.UpdateAsync(school, token);
            await _schoolRepository.SaveChangesAsync();

            var response = _mapper.Map<SchoolResponse>(school);

            return response;
        }


        public async Task<SchoolResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var school = await _schoolRepository.GetByIdAsync(id, token);

            if (school == null)
                throw new Exception("School not found");
            
            var response = _mapper.Map<SchoolResponse>(school);

            return response;
        }

        public async Task<ICollection<SchoolResponse>> GetOdataAsync(SearchSchoolRequest request, CancellationToken token)
        {
            var queryable = await _schoolRepository.GetQueryableAsync(request.ODataOptions, token);
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
