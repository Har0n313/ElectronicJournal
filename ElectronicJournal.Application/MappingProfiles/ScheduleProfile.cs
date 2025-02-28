using AutoMapper;
using ElectronicJournal.Application.Dtos.ScheduleDtos;
using ElectronicJournal.Domain.Entites;

namespace ElectronicJournal.Application.MappingProfiles;

public class ScheduleProfile : Profile
{
    public ScheduleProfile()
    {
        CreateMap<CreateScheduleRequest, Schedule>()
            .ForMember(dest => dest.SchoolClassId, opt => opt.MapFrom(src => src.SchoolClassId))
            .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));

        CreateMap<UpdateScheduleRequest, Schedule>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ScheduleId))
            .ForMember(dest => dest.SchoolClassId, opt => opt.MapFrom(src => src.SchoolClassId))
            .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));

        CreateMap<SearchScheduleRequest, Schedule>()
            .ForMember(dest => dest.SchoolClassId, opt => opt.MapFrom(src => src.SchoolClassId))
            .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time));

        CreateMap<Schedule, ScheduleResponse>()
            .ForMember(dest => dest.ScheduleId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SchoolClassId, opt => opt.MapFrom(src => src.SchoolClassId))
            .ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubjectId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
            .ConstructUsing(src => new ScheduleResponse(src.Id, src.SchoolClassId, src.SubjectId, src.Date, src.Time));
    }
}