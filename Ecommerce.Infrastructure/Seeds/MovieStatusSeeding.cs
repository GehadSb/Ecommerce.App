using Ecommerce.Domain.MovieAggregate.Entity;
using Ecommerce.Domain.MovieAggregate.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Seeds
{
    public static class MovieStatusSeeding
    {
        public static void Seed(EntityTypeBuilder<MovieStatus> entities)
        {
            entities.HasData(new[]
            {
                new MovieStatus(MovieStatusEnum.Available),
                new MovieStatus(MovieStatusEnum.Upcoming)
            });
            entities.OwnsOne(x => x.NameEn)
                    .HasData(new[]
                    {
                        new {MovieStatusId=MovieStatusEnum.Available,value="Available"},
                        new {MovieStatusId=MovieStatusEnum.Upcoming,value="Upcoming"}
                    });
        }

    }
}
