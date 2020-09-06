using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MovieCollection.Core.Context;

namespace MovieCollection.Core.Factories
{
    public class MovieCollectionContextFactory : IDesignTimeDbContextFactory<MovieCollectionContext>
    {
        public MovieCollectionContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieCollectionContext>();
            
            //TODO Строку подключения брать из appsettings
            optionsBuilder.UseSqlite("Filename=MovieCollection.db");
            
            
            return new MovieCollectionContext(optionsBuilder.Options);
        }
    }
}