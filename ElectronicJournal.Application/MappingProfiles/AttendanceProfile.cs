using AutoMapper;
using ElectronicJournal.Application.Dtos.AttendanceDtos;
using ElectronicJournal.Domain.Entites;


namespace ElectronicJournal.Application.MappingProfiles
{
    public class AttendanceProfile : Profile
    {
        public AttendanceProfile()
        {
            CreateMap<CreateAttendanceRequest, Attendance>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<UpdateAttendanceRequest, Attendance>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AttendanceId))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<SearchAttendanceRequest, Attendance>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Attendance, AttendanceResponse>()
                .ForMember(dest => dest.AttendanceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ConstructUsing(src => new AttendanceResponse(src.Id, src.StudentId, src.Date, src.Status)); ;
        }
    }
}
