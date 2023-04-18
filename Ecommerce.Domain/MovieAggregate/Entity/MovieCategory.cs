using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Enums;
using Ecommerce.Domain.ValueObjects.Auditables;

namespace Ecommerce.Domain.MovieAggregate.Entity
{
    public class MovieCategory : BaseEntity<MovieCategoryEnum>, ILookupNameEn
    {
        public virtual LookupNameEn NameEn { get; private set; }
        public virtual List<Movie> Movies { get; set; }

        protected MovieCategory()
        {
            Movies = new();
        }
        public MovieCategory(MovieCategoryEnum id)
        {
            Id = id;
        }
        public MovieCategory(MovieCategoryEnum id, string name) : this()
        {
            Id = id;
            NameEn = (LookupNameEn)name;
        }
    }
}
