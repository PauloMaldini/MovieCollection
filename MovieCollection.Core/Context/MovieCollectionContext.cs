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
            #endregion

            #region [ Фильмы ]            
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 1, Name = "Джанго освобожденный", Description = "", YearOfIssue = 2012, PosterFileName = "1e5bcf73adfd4685a205d8c318bd83d8.png", ProducerRefId = 1, Author = "user1" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 2, Name = "Криминальное чтиво", Description = "", YearOfIssue = 1994, PosterFileName = "", ProducerRefId = 1, Author = "user1" });
            modelBuilder.Entity<Movie>().HasData(new Movie
                { Id = 3, Name = "Бесславные ублюдки", Description = "", YearOfIssue = 2009, PosterFileName = "", ProducerRefId = 1, Author = "user2" });
            #endregion
        }
    }
}