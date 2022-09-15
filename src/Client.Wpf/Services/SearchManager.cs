using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Application.Common.Interfaces.Searchers;
using Application.Features.Movies.Responses;
using Application.Routes.Searchers;

namespace Client.Wpf.Services;
public class SearchManager : ISearchManager
{
    private readonly HttpClient _httpClient;

    public SearchManager(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetMovieSearchResults> GetSearchResults(string expression)
    {
        return await _httpClient.GetFromJsonAsync<GetMovieSearchResults>(SearchEndpoints.SearchMovie(expression));
    }
}
