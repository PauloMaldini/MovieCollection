using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieCollection.Core.Entities;

namespace MovieCollection.Core.Context
{
    public class MovieCollectionContext : IdentityDbContext
    {
        public MovieCollectionContext (DbContextOptions<MovieCollectionContext> options)
            : base(options)
        {
        }
        
        public DbSet<Movie> Movies { get; set; }
        
        public DbSet<Producer> Producers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            #region [ Пользователи ]
            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "1",
                UserName = "user1",
                NormalizedUserName = "USER1",
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "user1")
            });
            
            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "2",
                UserName = "user2",
                NormalizedUserName = "USER2",
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "user2")
            });
            #endregion
            
            #region [ Страны ]
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Россия" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "США" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Великобритания" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "Испания" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 5, Name = "Германия" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 6, Name = "Франция" });
            #endregion

            #region [ Режиссеры ]
            modelBuilder.Entity<Producer>().HasData(new Producer
                { Id = 1, FirstName = "Квентино", LastName = "Тарантино", DateOfBirth = DateTime.Parse("1963-03-27"), CountryRefId = 2 });
            modelBuilder.Entity<Producer>().HasData(new Producer
                { Id = 2, FirstName = "Стивен", LastName = "Спилберг", DateOfBirth = DateTime.Parse("1946-12-18"), CountryRefId = 2 });
            modelBuilder.Entity<Producer>().HasData(new Producer
                { Id = 3, FirstName = "Фрэнк", LastName = "Дарабонт", DateOfBirth = DateTime.Parse("1959-01-28"), CountryRefId = 6 });
            modelBuilder.Entity<Producer>().HasData(new Producer
                { Id = 4, FirstName = "Кристиан", LastName = "Альварт", DateOfBirth = DateTime.Parse("1974-05-28"), CountryRefId = 6 });
            modelBuilder.Entity<Producer>().HasData(new Producer
                { Id = 5, FirstName = "Джеймс", LastName = "Кэмерон", DateOfBirth = DateTime.Parse("1954-08-16"), CountryRefId = 6 });
            #endregion

            #region [ Фильмы ]            
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 1, Name = "Джанго освобожденный", Description = "", YearOfIssue = 2012, PosterFileName = "85157a5959894d3092f8a1cfb30cfcb5.png", ProducerRefId = 1, Author = "user1" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 2, Name = "Криминальное чтиво", Description = "", YearOfIssue = 1994, PosterFileName = "315d7e86ce92407886629fcec8e18fab.jpg", ProducerRefId = 1, Author = "user1" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 3, Name = "Бесславные ублюдки", Description = "", YearOfIssue = 2009, PosterFileName = "acdd66d16b944e25bfdd33249790ed2d.jpg", ProducerRefId = 1, Author = "user2" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 4, Name = "Побег из шоушенка", Description = "", YearOfIssue = 1994, PosterFileName = "ed952073c9f24e49a80f6cceb3cc9ba.jpg", ProducerRefId = 3, Author = "user2" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 5, Name = "Спасти рядового Райана", Description = "", YearOfIssue = 1998, PosterFileName = "fc7c8ae1d2c942d79958882086735ccd.png", ProducerRefId = 2, Author = "user1" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 6, Name = "Инопланетянин", Description = "", YearOfIssue = 1982, PosterFileName = "b119a9c2ead8460f958106540b1fecbe.jpg", ProducerRefId = 2, Author = "user1" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 7, Name = "Пандорум", Description = "", YearOfIssue = 2009, PosterFileName = "ffcd5ad118c74dafaac7b137607147d5.jpg", ProducerRefId = 4, Author = "user1" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 8, Name = "Терминатор", Description = "", YearOfIssue = 1984, PosterFileName = "9fadd792f1e94344a9138edf058ce9ab.jpg", ProducerRefId = 5, Author = "user2" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 9, Name = "Чужие", Description = "", YearOfIssue = 1986, PosterFileName = "274b54c8be6c42b5a39afad70b43b6c1.jpg", ProducerRefId = 5, Author = "user2" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 10, Name = "Терминатор 2: Судный день", Description = "", YearOfIssue = 1991, PosterFileName = "1a3a4c6c458c43a1bdf42da31932e789.jpg", ProducerRefId = 5, Author = "user1" });
           
            #endregion
        }
    }
}