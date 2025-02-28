using ElectronicJournal.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicJournal.Infrastructure.Dal.EntityFramework.Configuration;

internal class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder.HasKey(x => x.Id);

        builder.HasOne(s => s.SchoolClass)
            .WithMany(sc => sc.Schedules)
            .HasForeignKey(s => s.SchoolClassId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Subject)
            .WithMany()
            .HasForeignKey(s => s.SubjectId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}