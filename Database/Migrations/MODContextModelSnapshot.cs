// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MOD.Database.Contexts;

#nullable disable

namespace MOD.Membership.Database.Migrations
{
    [DbContext(typeof(MODContext))]
    partial class MODContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MOD.Membership.Database.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Koosha Yousefi"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jonas Fagerberg"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Oda Eichiro"
                        });
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.Property<string>("FilmUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Free")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Released")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "TES, test test test, test.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                            Free = true,
                            Released = new DateTime(2002, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spiderman"
                        },
                        new
                        {
                            Id = 2,
                            Description = "TES, test test test, test.",
                            DirectorId = 1,
                            FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                            Free = true,
                            Released = new DateTime(2007, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Batman"
                        },
                        new
                        {
                            Id = 3,
                            Description = "TES, test test test, test.",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                            Free = true,
                            Released = new DateTime(2009, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "A Miracle From Heaven"
                        },
                        new
                        {
                            Id = 4,
                            Description = "TES, test test test, test.",
                            DirectorId = 2,
                            FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                            Free = true,
                            Released = new DateTime(2008, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Seven Pound"
                        },
                        new
                        {
                            Id = 5,
                            Description = "TES, test test test, test.",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                            Free = true,
                            Released = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "One Piece Movie - Red"
                        },
                        new
                        {
                            Id = 6,
                            Description = "TES, test test test, test.",
                            DirectorId = 3,
                            FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                            Free = true,
                            Released = new DateTime(2017, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "One Piece Movie - Gold"
                        });
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("FilmGenres", (string)null);

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            GenreId = 1
                        },
                        new
                        {
                            FilmId = 1,
                            GenreId = 2
                        },
                        new
                        {
                            FilmId = 2,
                            GenreId = 1
                        },
                        new
                        {
                            FilmId = 2,
                            GenreId = 2
                        },
                        new
                        {
                            FilmId = 3,
                            GenreId = 4
                        },
                        new
                        {
                            FilmId = 4,
                            GenreId = 4
                        },
                        new
                        {
                            FilmId = 5,
                            GenreId = 1
                        },
                        new
                        {
                            FilmId = 5,
                            GenreId = 3
                        },
                        new
                        {
                            FilmId = 6,
                            GenreId = 1
                        },
                        new
                        {
                            FilmId = 6,
                            GenreId = 3
                        });
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Anime"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Drama"
                        });
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.SimilarFilm", b =>
                {
                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<int>("SimilarFilmId")
                        .HasColumnType("int");

                    b.HasKey("FilmId", "SimilarFilmId");

                    b.HasIndex("SimilarFilmId");

                    b.ToTable("SimilarFilms");

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            SimilarFilmId = 2
                        },
                        new
                        {
                            FilmId = 2,
                            SimilarFilmId = 1
                        },
                        new
                        {
                            FilmId = 3,
                            SimilarFilmId = 4
                        },
                        new
                        {
                            FilmId = 4,
                            SimilarFilmId = 3
                        },
                        new
                        {
                            FilmId = 5,
                            SimilarFilmId = 6
                        },
                        new
                        {
                            FilmId = 6,
                            SimilarFilmId = 5
                        });
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.Film", b =>
                {
                    b.HasOne("MOD.Membership.Database.Entities.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.FilmGenre", b =>
                {
                    b.HasOne("MOD.Membership.Database.Entities.Film", "Film")
                        .WithMany()
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MOD.Membership.Database.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.SimilarFilm", b =>
                {
                    b.HasOne("MOD.Membership.Database.Entities.Film", "Film")
                        .WithMany("SimilarFilms")
                        .HasForeignKey("FilmId")
                        .IsRequired();

                    b.HasOne("MOD.Membership.Database.Entities.Film", "Similar")
                        .WithMany()
                        .HasForeignKey("SimilarFilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Similar");
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.Director", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("MOD.Membership.Database.Entities.Film", b =>
                {
                    b.Navigation("SimilarFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
