using ElectronicJournal.Domain.Entites;
using ElectronicJournal.Domain.ValueObject;
using ElectronicJournal.Infrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace ElectronicJournal.Infrastructure.Dal.EntityFramework
{
    public class ElectronicJornalDbContext : DbContext
    {
        private readonly DataBaseSettings _options;

        public ElectronicJornalDbContext(IOptions<DataBaseSettings> options)
        {
            _options = options.Value;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SchoolClass> SchoolClasses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).IsRequired();
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Role).IsRequired();
            });


            // Настройка объекта значения FullName
            modelBuilder.Owned<FullName>();

            // Применение конфигураций из текущей сборки
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_options.ConnectionStrings, options =>
            {
                options.CommandTimeout(_options.CommandTimeout);
            });
        }
    }
}
