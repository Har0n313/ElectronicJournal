using ElectronicJournal.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ElectronicJournal.Infrastructure.Dal.EntityFramework.Configuration
{
    internal class SchoolClassConfiguration : IEntityTypeConfiguration<SchoolClass>
    {
        public void Configure(EntityTypeBuilder<SchoolClass> builder)
        {
            builder.ToTable("SchoolClass");

            builder.HasKey(x => x.Id);

            builder.HasOne(sc => sc.School)
                   .WithMany(s => s.SchoolClasses)
                   .HasForeignKey(sc => sc.SchoolId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.Teacher)
                   .WithMany(t => t.SchoolClasses)
                   .HasForeignKey(sc => sc.TeacherId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(sc => sc.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(sc => sc.Description)
                   .HasMaxLength(500);
        }
    }
}
