using Microsoft.AspNetCore.Components;
using MOD.Shared.DTOs;
using System.Net.Http.Json;

namespace MOD.Client.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        private HttpClient _httpClinet { get; set; }
        [Inject]
        protected NavigationManager _nav { get; set; }
        protected List<FilmDTO> _filmList { get; set; } = null;
        protected List<GenreDTO> _genreList { get; set; } = new();



        protected override void OnInitialized()
        {
            _httpClinet.GetFromJsonAsync<List<GenreDTO>>("/api/Genres").ContinueWith(e =>
            {
                _genreList = e.Result;
                StateHasChanged();
            });

            _httpClinet.GetFromJsonAsync<List<FilmDTO>>("/api/Film").ContinueWith(e =>
            {
                _filmList = e.Result;
                StateHasChanged();
            });
            base.OnInitialized();
        }
    }
}
