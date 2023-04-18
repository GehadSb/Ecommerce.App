using Ecommerce.Domain.MovieAggregate.Entity;
using Ecommerce.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Extentions
{
    public static class ContextSeedExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            //  MovieStatusSeeding.Seed(builder.Entity<MovieStatus>());
            //  MovieCategorySeeding.Seed(builder.Entity<MovieCategory>());
            CinemaSeeding.Seed(builder.Entity<Cinema>());
            //  MovieSeeding.Seed(builder.Entity<Movie>());
        }
    }
}
