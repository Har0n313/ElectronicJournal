using AutoMapper;
using ElectronicJournal.Application.Dtos.SchoolClassDtos;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.MappingProfiles
{
    public class SchoolClassProfile : Profile
    {
        public SchoolClassProfile()
        {
            CreateMap<CreateSchoolClassRequest, SchoolClass>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId));

            CreateMap<UpdateSchoolClassRequest, SchoolClass>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SchoolClassId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId));

            CreateMap<SearchSchoolClassRequest, SchoolClass>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId));

            CreateMap<SchoolClass, SchoolClassResponse>()
                .ForMember(dest => dest.SchoolClassId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId))
                .ConstructUsing(src => new SchoolClassResponse(src.Id, src.Name, src.Description, src.TeacherId, src.SchoolId));
        }
    }
}
