using ElectronicJournal.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicJournal.Infrastructure.Dal.EntityFramework.Configuration
{
    internal class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects");

            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Teacher)
                   .WithMany(t => t.Subjects)
                   .HasForeignKey(s => s.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(200);
        }
    }
}
