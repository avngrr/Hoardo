using Application.Common.Interfaces.Movies;
using Application.Features.Movies.Queries;
using Application.Features.Movies.Responses;
using Application.Mappings.Movies;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Server.Endpoints.Movies;

[HttpGet("movies"), AllowAnonymous]
public class GetAllMoviesEndpoint : Endpoint<GetAllPagedMoviesQuery, GetAllPagedMovieResponse>
{
    private readonly IMovieService _movieService;
    public GetAllMoviesEndpoint(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(GetAllPagedMoviesQuery query, CancellationToken cancellationToken)
    {
        var moviesList = await _movieService.GetAllPaged(query.PageNumber, query.PageSize);
        GetAllPagedMovieResponse result = new GetAllPagedMovieResponse()
        {
            MovieList = moviesList.Select(m => m.ToMovieResponse()).ToList(),
            TotalCount = moviesList.TotalCount,
            PageSize = moviesList.PageSize,
            TotalPages = moviesList.TotalPages,
            CurrentPage = moviesList.CurrentPage
        };
        await SendOkAsync(result, cancellationToken);
    }
}
