using MovieMarkApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace MovieMarkApi
{
    public class MovieMarkContext : DbContext
    {
        public MovieMarkContext(DbContextOptions<MovieMarkContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

    }
}
