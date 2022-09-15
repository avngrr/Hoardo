using Application.Common.Interfaces.Searchers;
using Application.Features.Movies.Queries;
using Application.Features.Movies.Responses;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Server.Endpoints.Searcher;

[HttpGet("search/movie"), AllowAnonymous]
public class SearchMovieEndpoint : Endpoint<GetSearchResultsQuery, GetMovieSearchResults>
{
    private readonly ISearchEngine _searchEngine;
    public SearchMovieEndpoint(ISearchEngine searchEngine)
    {
        _searchEngine = searchEngine;
    }
    public override async Task HandleAsync(GetSearchResultsQuery query, CancellationToken ct)
    {
        var searchResults = await _searchEngine.Search(query.Expression);
        GetMovieSearchResults result = new GetMovieSearchResults();
        result.MovieList = searchResults.Results.Select(movie => new MovieSearchResponse()
        {
            ImdbId = movie.Id,
            Title = movie.Title,
            ImageUrl = movie.Image,
            Added = false
        }).ToList();
        await SendOkAsync(result, ct);
    }
}
