using AutoMapper;
using ElectronicJournal.Application.Dtos.SchoolDtos;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.MappingProfiles;

public class SchoolProfile : Profile
{
    public SchoolProfile()
    {
        CreateMap<CreateSchoolRequest, School>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<UpdateSchoolRequest, School>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SchoolId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

        CreateMap<School, SchoolResponse>()
            .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ConstructUsing(src => new SchoolResponse(src.Id, src.Name, src.Address, src.Description));
    }
}