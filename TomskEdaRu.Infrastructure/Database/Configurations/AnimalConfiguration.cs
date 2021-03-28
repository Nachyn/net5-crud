using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TomskEdaRu.Domain.Entities;
using TomskEdaRu.Domain.Enums;

namespace TomskEdaRu.Infrastructure.Database.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animals");
            builder.Property(a => a.Type)
                .HasConversion(new EnumToNumberConverter<AnimalType, int>());
        }
    }
}