using Microsoft.AspNetCore.Mvc;

namespace MOD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDbService _db;

        public DirectorController(IDbService db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                List<DirectorDTO>? directors = await _db.GetAsync<Director, DirectorDTO>();

                return Results.Ok(directors);
            }
            catch
            {
            }

            return Results.NotFound();
        }


        [HttpGet("{id}")]

        public async Task<IResult> Get(int id)
        {
            _db.Include<Film>();
            try
            {

                var director = await _db.SingleAsync<Director, DirectorDTO>(c => c.Id.Equals(id));
                if (director is null) return Results.NotFound();

                return Results.Ok(director);
            }
            catch
            {
                return Results.NotFound();
            }
        }


        //EJ RIKTIG NÖJD FRÅGA JONAS
        [HttpPost]

        public async Task<IResult> Post([FromBody] DirectorDTO dto)
        {
            try
            {
                if (dto == null) return Results.BadRequest();

                var director = await _db.AddAsync<Director, DirectorDTO>(dto);

                var success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.Created(_db.GetURI<Director>(director), director);
            }
            catch
            {
                return Results.BadRequest();
            }
        }


        //funkar inte att uppdatera.
        [HttpPut("{id}")]

        public async Task<IResult> Put(int id, [FromBody] DirectorDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return Results.BadRequest("Ingen entitiy angiven");
                }

                if (!id.Equals(dto.Id))
                {
                    return Results.BadRequest("Id:n stämmer ej överrens");
                }

                var finns = await _db.AnyAsync<Director>(c => c.Id.Equals(id));
                if (!finns)
                {
                    return Results.NotFound();
                }

                if (!finns)
                {
                    return Results.NotFound();
                }

                _db.Update<Director, DirectorDTO>(dto.Id, dto);

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
                var success = await _db.DeleteAsync<Director>(id);

                if (!success) return Results.NotFound();

                success = await _db.SaveChangesAsync();

                if (!success) return Results.BadRequest();

                return Results.NoContent();
            }
            catch
            {
                return Results.BadRequest();
            }
        }
    }
}

