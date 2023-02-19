using Microsoft.AspNetCore.Mvc;
using MOD.Server.Utils;

namespace MOD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IDbService _db;

        public FilmController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get(bool freeOnly)
        {
            try
            {
                _db.Include<Director>();
                _db.Include<Film>();
                _db.Include<FilmGenre>();
                _db.Include<SimilarFilm>();
                List<FilmDTO>? filmer;
                if (freeOnly)
                {
                    filmer = await _db.GetAsync<Film, FilmDTO>(c => c.Free.Equals(freeOnly));
                }
                else
                {
                    filmer = await _db.GetAsync<Film, FilmDTO>();
                }

                return Results.Ok(JsonUtility.RemoveLoops(filmer));
            }
            catch
            {
                return Results.NotFound();
            }
        }


        [HttpGet("{id}")]

        public async Task<IResult> Get(int id)
        {
            try
            {
                // _db.Include<Director>();
                //_db.Include<Genre>();
                // Det här måste lösas asap
                _db.Include<Film>();
                _db.Include<FilmGenre>();
                _db.Include<SimilarFilm>();
                var film = await _db.SingleAsync<Film, FilmDTO>(c => c.Id.Equals(id));
                return Results.Ok(JsonUtility.RemoveLoops(film));
            }
            catch (Exception ex)
            {
                return Results.NotFound();
            }
        }


        //EJ RIKTIG NÖJD FRÅGA JONAS
        [HttpPost]

        public async Task<IResult> Post([FromBody] FilmCreateDTO dto)
        {
            try
            {
                if (dto == null)
                    return Results.BadRequest();

                var film = await _db.AddAsync<Film, FilmCreateDTO>(dto);
                var success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }
                //vad händer här?
                return Results.Ok();
            }
            catch
            {
                return Results.BadRequest();
            }
        }


        //funkar inte att uppdatera.
        [HttpPut("{id}")]

        public async Task<IResult> Put(int id, [FromBody] FilmEditDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return Results.BadRequest();
                }

                if (!id.Equals(dto.Id))
                {
                    return Results.BadRequest();
                }

                var finns = await _db.AnyAsync<Director>(i => i.Id.Equals(dto.DirectorId));
                if (!finns)
                {
                    return Results.NotFound();
                }
                finns = await _db.AnyAsync<Film>(i => i.Id.Equals(id));
                if (!finns)
                {
                    return Results.NotFound();
                }

                _db.Update<Film, FilmEditDTO>(dto.Id, dto);

                var success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }

                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public async Task<IResult> Delete(int id)
        {
            try
            {
                var success = await _db.DeleteAsync<Film>(id);
                if (!success)
                {
                    return Results.NotFound();
                }

                success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }
                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest();
            }
        }

    }
}
