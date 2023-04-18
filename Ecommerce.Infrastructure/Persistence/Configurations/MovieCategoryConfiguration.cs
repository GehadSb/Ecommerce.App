using Ecommerce.Domain.MovieAggregate.Entity;
using Ecommerce.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Configurations
{
    public class MovieCategoryConfiguration : IEntityTypeConfiguration<MovieCategory>
    {
        public void Configure(EntityTypeBuilder<MovieCategory> builder)
        {
            builder.ToTable(nameof(MovieCategory));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsNameEN();
        }
    }
}
