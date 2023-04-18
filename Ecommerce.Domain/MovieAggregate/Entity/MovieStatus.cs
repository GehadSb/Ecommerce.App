using Ecommerce.Domain.Common;
using Ecommerce.Domain.MovieAggregate.Enums;
using Ecommerce.Domain.ValueObjects.Auditables;

namespace Ecommerce.Domain.MovieAggregate.Entity
{
    public class MovieStatus : BaseEntity<MovieStatusEnum>, ILookupNameEn
    {
        public virtual LookupNameEn NameEn { get; private set; } = null!;
        public virtual List<Movie> Movies { get; set; }

        protected MovieStatus()
        {
            Movies = new();
        }
        public MovieStatus(MovieStatusEnum id)
        {
            Id = id;
        }
        public MovieStatus(MovieStatusEnum id, string name) : this(id)
        {
            NameEn = (LookupNameEn)name;
        }
    }
}
