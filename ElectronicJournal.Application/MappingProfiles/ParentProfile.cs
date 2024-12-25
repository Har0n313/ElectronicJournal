using AutoMapper;
using ElectronicJournal.Application.Dtos.ParentDtos;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.MappingProfiles
{
    public class ParentProfile : Profile
    {
        public ParentProfile() 
        {
            CreateMap<CreateParentRequest, Parent>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentId));

            CreateMap<UpdateParentRequest, Parent>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ParentId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentIds));

            CreateMap<SearchParentRequest, Parent>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.StudentId));

            CreateMap<Parent, ParentResponse>()
                .ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ConstructUsing(src => new ParentResponse(src.Id, src.FullName, src.Email, src.Students));
        }
    }
}
