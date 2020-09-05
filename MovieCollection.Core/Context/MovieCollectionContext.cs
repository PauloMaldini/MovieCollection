using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Entities;

namespace MovieCollection.Core.Context
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext (DbContextOptions<MovieCollectionContext> options)
            : base(options)
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Producer> Producers { get; set; }
    }
}