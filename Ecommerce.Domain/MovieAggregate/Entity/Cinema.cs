using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.MovieAggregate.Entity
{
    public class Cinema : BaseEntity<long>
    {
        public virtual string Name { get; private set; }
        public virtual string Description { get; private set; }
        public virtual List<Movie> Movies { get; set; }
        public Cinema()
        {
            Movies = new();
        }
        public Cinema(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
