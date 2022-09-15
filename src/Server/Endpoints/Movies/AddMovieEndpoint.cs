using Application.Common.Interfaces.Movies;
using Application.Common.Interfaces.Searchers;
using Application.Features.Movies.Commands;
using Domain.Entities.Movies;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Server.Endpoints.Movies;
[HttpPost("movies"), AllowAnonymous]
public class AddMovieEndpoint : Endpoint<CreateMovieCommand>
{
    private readonly IMovieService _movieService;
    private readonly ISearchEngine _searchEngine;

    public AddMovieEndpoint(IMovieService movieService, ISearchEngine searchEngine)
    {
        _movieService = movieService;
        _searchEngine = searchEngine;
    }

    public override async Task HandleAsync(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        var movieData = await _searchEngine.GetMovieData(command.ImdbId);
        if (movieData.Id == null) await SendNotFoundAsync(cancellationToken);
        await _movieService.AddAsync(new Movie()
        {
            ImdbId = movieData.Id,
            Title = movieData.Title,
            CleanTitle = movieData.Title,
            ImageUrl = movieData.Image,
            Overview = movieData.Plot,
            Year = int.Parse(movieData.Year),
            Monitored = true,
            HasSeen = false
        });
        await SendOkAsync(cancellationToken);
    }
}
