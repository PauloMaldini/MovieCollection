﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCollection.Core.Context;

namespace MovieCollection.Core.Migrations
{
    [DbContext(typeof(MovieCollectionContext))]
    partial class MovieCollectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7");

            modelBuilder.Entity("MovieCollection.Core.Entities.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Deleted = false,
                            Name = "Россия"
                        },
                        new
                        {
                            Id = 2L,
                            Deleted = false,
                            Name = "США"
                        },
                        new
                        {
                            Id = 3L,
                            Deleted = false,
                            Name = "Великобритания"
                        },
                        new
                        {
                            Id = 4L,
                            Deleted = false,
                            Name = "Испания"
                        },
                        new
                        {
                            Id = 5L,
                            Deleted = false,
                            Name = "Германия"
                        },
                        new
                        {
                            Id = 6L,
                            Deleted = false,
                            Name = "Франция"
                        });
                });

            modelBuilder.Entity("MovieCollection.Core.Entities.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Poster")
                        .HasColumnType("TEXT");

                    b.Property<long>("ProducerRefId")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("BLOB");

                    b.Property<int>("YearOfIssue")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProducerRefId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Deleted = false,
                            Description = "",
                            Name = "Джанго освобожденный",
                            Poster = "",
                            ProducerRefId = 1L,
                            YearOfIssue = 2012
                        },
                        new
                        {
                            Id = 2L,
                            Deleted = false,
                            Description = "",
                            Name = "Криминальное чтиво",
                            Poster = "",
                            ProducerRefId = 1L,
                            YearOfIssue = 1994
                        },
                        new
                        {
                            Id = 3L,
                            Deleted = false,
                            Description = "",
                            Name = "Бесславные ублюдки",
                            Poster = "",
                            ProducerRefId = 1L,
                            YearOfIssue = 2009
                        });
                });

            modelBuilder.Entity("MovieCollection.Core.Entities.Producer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<long>("CountryRefId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.HasIndex("CountryRefId");

                    b.ToTable("Producers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CountryRefId = 2L,
                            DateOfBirth = new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Deleted = false,
                            FirstName = "Квентино",
                            LastName = "Тарантино"
                        });
                });

            modelBuilder.Entity("MovieCollection.Core.Entities.Movie", b =>
                {
                    b.HasOne("MovieCollection.Core.Entities.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCollection.Core.Entities.Producer", b =>
                {
                    b.HasOne("MovieCollection.Core.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}