using AutoMapper;
using ElectronicJournal.Application.Dtos.TeacherDtos;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.MappingProfiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            CreateMap<CreateTeacherRequest, Teacher>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.AcademicDegree, opt => opt.MapFrom(src => src.AcademicDegree))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SchollId, opt => opt.MapFrom(src => src.SchoolId));

            CreateMap<UpdateTeacherRequest, Teacher>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.AcademicDegree, opt => opt.MapFrom(src => src.AcademicDegree))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SchollId, opt => opt.MapFrom(src => src.SchoolId));

            CreateMap<SearchTeacherRequest, Teacher>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.AcademicDegree, opt => opt.MapFrom(src => src.AcademicDegree))
                .ForMember(dest => dest.SchollId, opt => opt.MapFrom(src => src.SchoolId));

            CreateMap<Teacher, TeacherResponse>()
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.AcademicDegree, opt => opt.MapFrom(src => src.AcademicDegree))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchollId))
                .ConstructUsing(src => new TeacherResponse(src.Id, src.FullName, src.Email, src.SchollId, src.AcademicDegree, src.Description));
        }
    }
}
