using Application.Common.Interfaces.Movies;
using Application.Features.Movies.Commands;
using Application.Mappings.Movies;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Server.Endpoints.Movies;
[HttpPost("movies"), AllowAnonymous]
public class AddMovieEndpoint : Endpoint<CreateMovieCommand>
{
    private readonly IMovieService _movieService;
    public AddMovieEndpoint(IMovieService movieService)
    {
        _movieService = movieService;
    }

    public override async Task HandleAsync(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        await _movieService.AddAsync(command.ToMovie());
        await SendOkAsync(cancellationToken);
    }
}
