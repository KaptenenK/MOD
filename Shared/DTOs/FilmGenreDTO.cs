using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD.Shared.DTOs
{
    public class FilmGenreDTO
    {
        public int? FilmId { get; set; }
        public int? GenreId { get; set; }

        //public FilmGenreDTO(int filmId, int genreId) => (FilmId, GenreId) = (filmId, genreId);
    }
}
