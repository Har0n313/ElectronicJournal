using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Interfaces.Services;
using ElectronicJournal.Application.Services;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using ElectronicJournal.Infrastructure.Dal.Models;
using ElectronicJournal.Infrastructure.Dal.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();
builder.Services.AddScoped<ISchoolClassService, SchoolClassService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();

builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app);

app.Run();

/// <summary>
/// Конфигурация сервисов
/// </summary>
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.Configure<DataBaseSettings>(configuration.GetSection(nameof(DataBaseSettings)));

    services.AddDbContext<ElectronicJornalDbContext>((serviceProvider, options) =>
    {
        var dataBaseSettings = serviceProvider.GetRequiredService<IOptions<DataBaseSettings>>().Value;

        options.UseNpgsql(dataBaseSettings.ConnectionStrings, npgsqlOptions =>
        {
            npgsqlOptions.CommandTimeout(dataBaseSettings.CommandTimeout);
        });
    });

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Electronic Journal API",
            Description = "API for managing attendance, grades, and other school-related data."
        });
    });
}

/// <summary>
/// Конфигурация middleware приложения
/// </summary>
void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Staging"))
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Electronic Journal API v1");
            options.RoutePrefix = string.Empty; 
        });
    }

    app.UseAuthorization();

    app.MapControllers();
}
