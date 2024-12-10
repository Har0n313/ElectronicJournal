using ElectronicJournal.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicJournal.Infrastructure.Dal.EntityFramework.Configuration
{
    internal class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.ToTable("Grades");

            builder.HasKey(x => x.Id);

            builder.HasOne(g => g.Student)
                   .WithMany(s => s.Grades)
                   .HasForeignKey(g => g.StudentId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(g => g.Subject)
                   .WithMany(s => s.Grades) 
                   .HasForeignKey(g => g.SubjectId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
