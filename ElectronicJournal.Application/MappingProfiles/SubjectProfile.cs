using AutoMapper;
using ElectronicJournal.Application.Dtos.SubjectDtos;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.MappingProfiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<CreateSubjectRequest, Subject>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId));

            CreateMap<UpdateSubjectRequest, Subject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId));

            CreateMap<SearchSubjectRequest, Subject>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId));

            CreateMap<Subject, SubjectResponse>()
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.TeacherId, opt => opt.MapFrom(src => src.TeacherId))
                .ConstructUsing(src => new SubjectResponse(src.Id, src.Name, src.TeacherId));
        }
    }
}
