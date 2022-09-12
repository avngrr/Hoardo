using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Common.Interfaces.Movies;
using Application.Features.Movies.Commands;
using Application.Features.Movies.Responses;
using Application.Routes.Movies;

namespace Client.Wpf.Services;
public class MovieManager : IMovieManager
{
    private readonly HttpClient _httpClient;

    public MovieManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<GetAllPagedMovieResponse> GetAllPaged(int pageNumber, int pageSize)
    {
        return await _httpClient.GetFromJsonAsync<GetAllPagedMovieResponse>(MovieEndpoints.GetAllPagedMovies(pageNumber, pageSize));
    }

    public async Task SaveAsync(CreateMovieCommand command)
    {
        var result = await _httpClient.PostAsJsonAsync(MovieEndpoints.AddMovie, command);
    }
}
