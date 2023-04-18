using Ecommerce.Application.Common.Interfaces;
using Ecommerce.Domain.MovieAggregate;
using Ecommerce.Domain.MovieAggregate.Entity;
using Ecommerce.Domain.OrderAggregate;
using Ecommerce.Domain.OrderAggregate.Entity;
using Ecommerce.Domain.ShoppingCartItemAggregate;
using Ecommerce.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence.context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // TODO: Add DbSet<Entity> here

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<MovieCategory> MovieCategory { get; set; }
        public DbSet<MovieStatus> MovieStatus { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        /// <summary>
        /// Apply the fluent API configurations
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // TODO: Add Fluent API entities configurations like the following code
            // builder.ApplyConfiguration(new ApplicationUserConfiguration());

            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            builder.Seed();
        }
    }
}
