using ElectronicJournal.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicJournal.Infrastructure.Dal.EntityFramework.Configuration
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasKey(x => x.Id);

            builder.HasOne(t => t.School)
                   .WithMany(s => s.Teachers)
                   .HasForeignKey(t => t.SchollId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(t => t.AcademicDegree)
                   .HasMaxLength(200);

            builder.Property(t => t.Description)
                   .HasMaxLength(500);
        }
    }
}
