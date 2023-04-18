using Ecommerce.Domain.MovieAggregate.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Seeds
{
    public static class CinemaSeeding
    {
        public static void Seed(this EntityTypeBuilder<Cinema> entities)
        {
            entities.HasData(new[]
            {
                new Cinema(1,"GlaxyCinema","Comfortable Cinema have Child Games. "),
                new Cinema(2,"ElthrirCinema","Good Cinema have different movies. "),
            });

        }
    }
}
