using ElectronicJournal.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicJournal.Infrastructure.Dal.EntityFramework.Configuration
{
    internal class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("Schools");

            builder.HasKey(x => x.Id);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(s => s.Address)
                   .IsRequired()
                   .HasMaxLength(300);

            builder.Property(s => s.Description)
                   .HasMaxLength(1000);
        }
    }
}
