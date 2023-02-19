using System.Web;

namespace MOD.Shared.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? Released { get; set; }
        public bool Free { get; set; }
        public string Description { get; set; }
        public string FilmUrl { get; set; }

        public int DirectorId { get; set; }
        public DirectorDTO Director { get; set; } = new();


        public List<GenreDTO>? Genres { get; set; } = new();
        public List<SimilarFilmDTO>? SimilarFilms { get; set; } = new();

        public string GetVideoId()
        {
            try
            {
                return HttpUtility.ParseQueryString(new Uri(FilmUrl).Query).Get("v");
            }
            catch
            {
                return null;
            }
        }
    }

    public class FilmCreateDTO
    {
        public string Title { get; set; }
        public DateTime? Released { get; set; } = DateTime.Today;
        public bool Free { get; set; }
        public string Description { get; set; }
        public string FilmUrl { get; set; }

        public int DirectorId { get; set; }
    }

    public class FilmEditDTO : FilmCreateDTO
    {
        public int Id { get; set; }
    }
}
