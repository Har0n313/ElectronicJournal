using ElectronicJournal.Application.Dtos.ParentDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.ValueObject;
using System.Linq;

namespace ElectronicJournal.Application.Services
{
    public class ParentService : IParentService
    {
        public readonly IParentRepository _parentRepository;

        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        public async Task<ParentResponse> CreateAsync(CreateParentRequest request, CancellationToken token)
        {
            var parent = new Parent
            {
                FullName = new FullName(request.FirstName, request.LastName, request?.MiddleName),
                DateofBirth = request.dateofBith,
            };

            await _parentRepository.AddAsync(parent, token);
            await _parentRepository.SaveChangesAsync();

            return new ParentResponse(parent.Id, parent.FullName, parent.DateofBirth);
        }

        public async Task<ParentResponse> UpdateAsync(UpdateParentRequest request, CancellationToken token)
        {
            var parent = await _parentRepository.GetByIdAsync(request.ParentId, token);

            if (parent == null)
                throw new Exception("Parent not found");

            parent.FullName = new FullName(request.FirstName, request.LastName, request?.MiddleName);
            parent.DateofBirth = request.dateOfBith;

            await _parentRepository.UpdateAsync(parent, token);
            await _parentRepository.SaveChangesAsync();

            return new ParentResponse(parent.Id,parent.FullName, parent.DateofBirth);

        }

        public async Task<ParentResponse> GetByIdAsync(Guid id, CancellationToken token)
        {
            var parent = await _parentRepository.GetByIdAsync(id, token);

            if (parent == null)
                throw new Exception("Parent not found");

            return new ParentResponse(parent.Id, parent.FullName, parent.DateofBirth);
        }
        public async Task<ICollection<ParentResponse>> GetOdataAsync(SearchParentRequest request, CancellationToken token)
        {
            var options = request.ToODataQueryOptions<Parent>();
            var queryable = await _parentRepository.GetQueryableAsync(options, token);
            var result = queryable.ToList();

            return result.Select(a =>
                new ParentResponse(a.Id, a.FullName, a.DateofBirth)).ToList();
        }

        public async Task<bool> DeleteAsync(Guid parentId, CancellationToken token)
        {
            var parent = await _parentRepository.GetByIdAsync(parentId, token);

            if(parent == null)
                return false;

            await _parentRepository.DeleteAsync(parent, token);
            await _parentRepository.SaveChangesAsync();

            return true;
        }
    }
}
