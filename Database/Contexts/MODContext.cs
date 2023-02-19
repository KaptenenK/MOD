using MOD.Database.Entities;

namespace MOD.Database.Contexts
{
    public class MODContext : DbContext
    {
        public virtual DbSet<Film> Films { get; set; } = null!;
        public virtual DbSet<SimilarFilm> SimilarFilms { get; set; } = null!;
        public virtual DbSet<Director> Directors { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<FilmGenre> FilmGenres { get; set; } = null!;

        public MODContext(DbContextOptions<MODContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SimilarFilm>().HasKey(ci => new { ci.FilmId, ci.SimilarFilmId });
            modelBuilder.Entity<FilmGenre>().HasKey(ci => new { ci.FilmId, ci.GenreId });


            modelBuilder.Entity<Film>(entity =>
            {
                entity
                    .HasMany(d => d.SimilarFilms)
                    .WithOne(p => p.Film)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasMany(d => d.Genres)
                      .WithMany(p => p.Films)
                      .UsingEntity<FilmGenre>()
                      .ToTable("FilmGenres");
            });

            /* Seed Data */
            modelBuilder.Entity<Director>().HasData(
                new { Id = 1, Name = "Koosha Yousefi" },
                new { Id = 2, Name = "Jonas Fagerberg" },
                new { Id = 3, Name = "Oda Eichiro" }

                );

            modelBuilder.Entity<Film>().HasData(
                new
                {
                    Id = 1,
                    Title = "Spiderman",
                    Description = "TES, test test test, test.",
                    DirectorId = 1,
                    Free = true,
                    FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                    Released = new DateTime(2002, 01, 15)
                },
                new
                {
                    Id = 2,
                    Title = "Batman",
                    Description = "TES, test test test, test.",
                    DirectorId = 1,
                    Free = true,
                    FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                    Released = new DateTime(2007, 01, 15)
                },
                new
                {
                    Id = 3,
                    Title = "A Miracle From Heaven",
                    Description = "TES, test test test, test.",
                    DirectorId = 2,
                    Free = true,
                    FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                    Released = new DateTime(2009, 01, 15)
                },
                new
                {
                    Id = 4,
                    Title = "Seven Pound",
                    Description = "TES, test test test, test.",
                    DirectorId = 2,
                    Free = true,
                    FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                    Released = new DateTime(2008, 01, 15)
                },
                new
                {
                    Id = 5,
                    Title = "One Piece Movie - Red",
                    Description = "TES, test test test, test.",
                    DirectorId = 3,
                    Free = true,
                    FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                    Released = new DateTime(2022, 01, 15)
                },
                new
                {
                    Id = 6,
                    Title = "One Piece Movie - Gold",
                    Description = "TES, test test test, test.",
                    DirectorId = 3,
                    Free = true,
                    FilmUrl = "https://www.youtube.com/watch?v=YRFc59pFANg",
                    Released = new DateTime(2017, 01, 15)
                }


                );


            modelBuilder.Entity<SimilarFilm>().HasData(
                new SimilarFilm { FilmId = 1, SimilarFilmId = 2 },
                new SimilarFilm { FilmId = 2, SimilarFilmId = 1 },
                new SimilarFilm { FilmId = 3, SimilarFilmId = 4 },
                new SimilarFilm { FilmId = 4, SimilarFilmId = 3 },
                new SimilarFilm { FilmId = 5, SimilarFilmId = 6 },
                new SimilarFilm { FilmId = 6, SimilarFilmId = 5 }
                );

            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Action" },
                new { Id = 2, Name = "Fantasy" },
                new { Id = 3, Name = "Anime" },
                new { Id = 4, Name = "Drama" }
                );

            modelBuilder.Entity<FilmGenre>().HasData(
                new FilmGenre { FilmId = 1, GenreId = 1 },
                new FilmGenre { FilmId = 1, GenreId = 2 },
                new FilmGenre { FilmId = 2, GenreId = 1 },
                new FilmGenre { FilmId = 2, GenreId = 2 },
                new FilmGenre { FilmId = 3, GenreId = 4 },
                new FilmGenre { FilmId = 4, GenreId = 4 },
                new FilmGenre { FilmId = 5, GenreId = 1 },
                new FilmGenre { FilmId = 5, GenreId = 3 },
                new FilmGenre { FilmId = 6, GenreId = 1 },
                new FilmGenre { FilmId = 6, GenreId = 3 }

                );
        }

    }
}
