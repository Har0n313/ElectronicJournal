using AutoMapper;
using ElectronicJournal.Application.Dtos.StudentDtos;
using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.ValueObject;

namespace ElectronicJournal.Application.MappingProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<CreateStudentRequest, Student>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                .ForMember(dest => dest.ShoolClassId, opt => opt.MapFrom(src => src.SchoolClassId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<UpdateStudentRequest, Student>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.ShoolClassId, opt => opt.MapFrom(src => src.SchoolClassId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<UpdateStudentRequest, Student>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => new FullName(src.FirstName, src.LastName, src.MiddleName)))
                .ForMember(dest => dest.ShoolClassId, opt => opt.MapFrom(src => src.SchoolClassId))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.SchoolClassId, opt => opt.MapFrom(src => src.ShoolClassId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ConstructUsing(src => new StudentResponse(src.Id, src.FullName, src.Email, src.ShoolClassId, src.Description));
        }
    }
}
