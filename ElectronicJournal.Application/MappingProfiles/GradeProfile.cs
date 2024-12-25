using AutoMapper;
using ElectronicJournal.Application.Dtos.GradeDtos;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.MappingProfiles
{
    public class GradeProfile : Profile
    {
        public GradeProfile()
        {
            CreateMap<CreateGradeRequest, Grade>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

            CreateMap<UpdateGradeRequest, Grade>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.GradeId))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment));

            CreateMap<SearchGradeRequest, Grade>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));

            CreateMap<Grade, GradeResponse>()
                .ForMember(dest => dest.GradeId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.SubjectId))
                .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Comment))
                .ConstructUsing(src => new GradeResponse(src.Id, src.StudentId, src.SubjectId, src.Date, src.Value, src.Comment));
        }
    }
}
