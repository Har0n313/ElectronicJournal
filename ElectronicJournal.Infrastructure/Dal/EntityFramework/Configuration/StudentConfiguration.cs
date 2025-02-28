using ElectronicJournal.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicJournal.Infrastructure.Dal.EntityFramework.Configuration;

internal class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        builder.HasKey(x => x.Id);

        builder.HasOne(s => s.SchoolClass)
            .WithMany(sc => sc.Students)
            .HasForeignKey(s => s.ShoolClassId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(s => s.Parents)
            .WithMany(p => p.Students)
            .UsingEntity(j => j.ToTable("StudentParents"));
    }
}