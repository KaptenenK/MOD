using Microsoft.EntityFrameworkCore;
using MOD.Database.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MODContext>(
options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MODConnection")));
builder.Services.AddScoped<IDbService, DbService>();

ConfigureAutomapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapWhen(ctx => ctx.Request.Path.StartsWithSegments("/admin"), app1 =>
{
    app1.UseBlazorFrameworkFiles("/admin");
    app1.UseRouting();
    app1.UseEndpoints(endpoints =>
    {
        endpoints.MapFallbackToFile("/admin/{*path:nonfile}", "/admin/index.html");
    });
});

app.UseBlazorFrameworkFiles("");
app.UseStaticFiles();

app.UseRouting();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

void ConfigureAutomapper()
{
    var config = new AutoMapper.MapperConfiguration(cfg =>
    {

        //Director mapping
        cfg.CreateMap<Director, DirectorDTO>()
        .ReverseMap();


        cfg.CreateMap<Genre, GenreDTO>().ReverseMap();



        //Films mapping

        cfg.CreateMap<Film, FilmDTO>().ReverseMap()
        .ForMember(dest => dest.Director, src => src.Ignore());

        cfg.CreateMap<FilmEditDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.Genres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());

        cfg.CreateMap<FilmCreateDTO, Film>()
        .ForMember(dest => dest.Director, src => src.Ignore())
        .ForMember(dest => dest.Genres, src => src.Ignore())
        .ForMember(dest => dest.SimilarFilms, src => src.Ignore());

        //Genre
        cfg.CreateMap<FilmGenre, FilmGenreDTO>().ReverseMap();

        //SimilarFilms

        cfg.CreateMap<SimilarFilm, SimilarFilmDTO>().ReverseMap();

    });
    var mapper = config.CreateMapper();
    builder.Services.AddSingleton(mapper);
}
