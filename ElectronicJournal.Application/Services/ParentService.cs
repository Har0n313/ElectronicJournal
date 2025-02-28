using AutoMapper;
using ElectronicJournal.Application.Dtos.ParentDtos;
using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.Services;

public class ParentService : IParentService
{
    private readonly IParentRepository _parentRepository;
    private readonly IRegistrationRepository _registrationRepository;
    private readonly IMapper _mapper;

    public ParentService(IParentRepository parentRepository, IMapper mapper)
    {
        _parentRepository = parentRepository;
        _mapper = mapper;
    }

    public async Task<ParentResponse> CreateAsync(CreateParentRequest request, CancellationToken token)
    {
        var isEmailTaken = await _registrationRepository.IsEmailTakenAsync(request.Email, token);
        if (isEmailTaken)
        {
            throw new InvalidOperationException("A user with this email already exists.");
        }

        var hashpassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var parent = _mapper.Map<Parent>(request);

        var createParent = _parentRepository.AddAsync(parent, token);
        await _parentRepository.SaveChangesAsync();

        var respone = _mapper.Map<ParentResponse>(createParent);

        return respone;
    }

    public async Task<ParentResponse> UpdateAsync(UpdateParentRequest request, CancellationToken token)
    {
        var parent = await _parentRepository.GetByIdAsync(request.ParentId, token);

        if (parent == null)
            throw new Exception("Parent not found");

        _mapper.Map(request, parent);

        await _parentRepository.UpdateAsync(parent, token);
        await _parentRepository.SaveChangesAsync();

        var respone = _mapper.Map<ParentResponse>(parent);

        return respone;
    }

    public async Task<ParentResponse> GetByIdAsync(Guid id, CancellationToken token)
    {
        var parent = await _parentRepository.GetByIdAsync(id, token);

        if (parent == null)
            throw new Exception("Parent not found");

        var response = _mapper.Map<ParentResponse>(parent);

        return response;
    }

    public async Task<ICollection<ParentResponse>> GetOdataAsync(SearchParentRequest request, CancellationToken token)
    {
        var options = request.ToODataQueryOptions<Parent>();
        var queryable = await _parentRepository.GetQueryableAsync(options, token);
        var result = queryable.ToList();

        return (ICollection<ParentResponse>)result;
    }

    public async Task<bool> DeleteAsync(Guid parentId, CancellationToken token)
    {
        var parent = await _parentRepository.GetByIdAsync(parentId, token);

        if (parent == null)
            return false;

        await _parentRepository.DeleteAsync(parent, token);
        await _parentRepository.SaveChangesAsync();

        return true;
    }
}