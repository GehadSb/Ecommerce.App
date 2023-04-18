using Ecommerce.Domain.MovieAggregate.Entity;
using Ecommerce.Domain.MovieAggregate.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.Seeds
{
    public static class MovieCategorySeeding
    {
        public static void Seed(this EntityTypeBuilder<MovieCategory> entities)
        {
            entities.HasData(new[]
            {
                new MovieCategory(MovieCategoryEnum.drama),
                new MovieCategory(MovieCategoryEnum.Action),
                new MovieCategory(MovieCategoryEnum.Horror),
                new MovieCategory(MovieCategoryEnum.Comedy),
                new MovieCategory(MovieCategoryEnum.Romance)
            });
            entities.OwnsOne(x => x.NameEn)
                   .HasData(new[]
                   {
                        new {MovieCategoryId=MovieCategoryEnum.drama,value="drama"},
                        new {MovieCategoryId=MovieCategoryEnum.Action,value="Action"},
                        new {MovieCategoryId=MovieCategoryEnum.Horror,value="Horror"},
                        new {MovieCategoryId=MovieCategoryEnum.Comedy,value="Comedy"},
                        new {MovieCategoryId=MovieCategoryEnum.Romance,value="Romance"}
                   });
        }
    }
}
