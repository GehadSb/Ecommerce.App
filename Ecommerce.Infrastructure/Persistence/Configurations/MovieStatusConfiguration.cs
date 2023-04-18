using Ecommerce.Domain.MovieAggregate.Entity;
using Ecommerce.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Configurations
{
    public class MovieStatusConfiguration : IEntityTypeConfiguration<MovieStatus>
    {
        public void Configure(EntityTypeBuilder<MovieStatus> builder)
        {
            builder.ToTable(nameof(MovieStatus));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsNameEN();
        }
    }
}
