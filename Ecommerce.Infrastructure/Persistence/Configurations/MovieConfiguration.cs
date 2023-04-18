using Ecommerce.Domain.MovieAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable(nameof(Movie));
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.MovieName).IsRequired();

            builder.HasOne(e => e.MovieCategory)
                .WithMany(e => e.Movies)
                .IsRequired()
                .HasForeignKey(e => e.MovieCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Cinema)
             .WithMany(e => e.Movies)
             .IsRequired()
             .HasForeignKey(e => e.CinemaId)
             .OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne<MovieStatus>()
            //    .WithMany()
            //    .HasForeignKey(x => x.MovieStatusId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
