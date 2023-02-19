using Microsoft.AspNetCore.Mvc;


namespace MOD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IDbService _db;

        public GenresController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<GenreDTO>? genres = await _db.GetAsync<Genre, GenreDTO>();
                return Results.Ok(genres);
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
                //_db.Include<Film>();
                //_db.Include<Genre>();
                // Det här måste lösas asap
                // _db.Include<SimilarFilm>();

                var genres = await _db.SingleAsync<Genre, GenreDTO>(c => c.Id.Equals(id));
                return Results.Ok(genres);
            }
            catch
            {
                return Results.NotFound();
            }
        }


        //EJ RIKTIG NÖJD FRÅGA JONAS
        [HttpPost]

        public async Task<IResult> Post([FromBody] GenreDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return Results.BadRequest();
                }

                var genre = await _db.AddAsync<Genre, GenreDTO>(dto);
                var success = await _db.SaveChangesAsync();
                if (!success)
                {
                    return Results.BadRequest();
                }
                //vad händer här?
                return Results.Created(_db.GetURI<Genre>(genre), genre);
            }
            catch
            {
                return Results.BadRequest();
            }

        }


        ////funkar inte att uppdatera.
        [HttpPut("{id}")]

        public async Task<IResult> Put(int id, [FromBody] GenreDTO dto)
        {
            try
            {
                if (dto == null)
                    return Results.BadRequest();

                if (!id.Equals(dto.Id))
                    return Results.BadRequest();

                _db.Update<Genre, GenreDTO>(dto.Id, dto);

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
                var success = await _db.DeleteAsync<Genre>(id);
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
