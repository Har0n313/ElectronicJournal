using ElectronicJournal.Application.Interfaces.Repositories;
using ElectronicJournal.Application.Services;
using ElectronicJournal.Infrastructure.Dal.EntityFramework;
using ElectronicJournal.Infrastructure.Dal.Models;
using ElectronicJournal.Infrastructure.Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<AttendanceService>();
builder.Services.AddScoped<GradeService>();
builder.Services.AddScoped<ParentService>();
builder.Services.AddScoped<ScheduleService>();
builder.Services.AddScoped<SchoolService>();
builder.Services.AddScoped<SchoolClassService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<TeacherService>();

builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();

// Добавляем сервисы в контейнер
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Настраиваем промежуточное ПО (Middleware)
ConfigureMiddleware(app);

app.Run();

/// <summary>
/// Конфигурация сервисов
/// </summary>
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Настройка параметров базы данных
    services.Configure<DataBaseSettings>(configuration.GetSection(nameof(DataBaseSettings)));

    // Настройка DbContext
    services.AddDbContext<ElectronicJornalDbContext>((serviceProvider, options) =>
    {
        var dataBaseSettings = serviceProvider.GetRequiredService<IOptions<DataBaseSettings>>().Value;

        options.UseNpgsql(dataBaseSettings.ConnectionStrings, npgsqlOptions =>
        {
            npgsqlOptions.CommandTimeout(dataBaseSettings.CommandTimeout);
        });
    });

    // Добавляем контроллеры
    services.AddControllers();

    // Настраиваем Swagger
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
    // Подключаем Swagger в режиме разработки и тестирования
    if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Staging"))
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Electronic Journal API v1");
            options.RoutePrefix = string.Empty; // Swagger доступен по корню URL
        });
    }

    // Настройка авторизации
    app.UseAuthorization();

    // Маршрутизация контроллеров
    app.MapControllers();
}
