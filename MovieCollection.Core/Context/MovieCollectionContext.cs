using System;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Россия" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "США" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Великобритания" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "Испания" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Германия" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 6, Name = "Франция" });

            modelBuilder.Entity<Producer>().HasData(new Producer
                { Id = 1, FirstName = "Квентино", LastName = "Тарантино", DateOfBirth = DateTime.Parse("1963-03-27"), CountryRefId = 2 });
            modelBuilder.Entity<Producer>().HasData(new Producer
                { Id = 2, FirstName = "Стивен", LastName = "Спилберг", DateOfBirth = DateTime.Parse("1946-12-18"), CountryRefId = 2 });


            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 1, Name = "Джанго освобожденный", Description = "", YearOfIssue = 2012, PosterFileName = "1e5bcf73adfd4685a205d8c318bd83d8.png", ProducerRefId = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 2, Name = "Криминальное чтиво", Description = "", YearOfIssue = 1994, PosterFileName = "", ProducerRefId = 1 });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 3, Name = "Бесславные ублюдки", Description = "", YearOfIssue = 2009, PosterFileName = "", ProducerRefId = 1 });
        }
    }
}