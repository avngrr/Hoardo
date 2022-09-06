using Application.Features.Movies.Commands;
using Application.Features.Movies.Responses;
using Domain.Entities.Movies;

namespace Application.Mappings.Movies;
public static class MovieMappings
{
    public static MovieResponse ToMovieResponse(this Movie movie)
    {
        return new MovieResponse
        {
            ImdbId = movie.ImdbId,
            Title = movie.Title,
            CleanTitle = movie.CleanTitle,
            Overview = movie.Overview,
            Monitored = movie.Monitored,
            Year = movie.Year,
            Genres = movie.Genres,
            Added = movie.Added
        };
    }
    public static Movie ToMovie(this MovieResponse response)
    {
        return new Movie
        {
            ImdbId = response.ImdbId,
            Title = response.Title,
            CleanTitle = response.CleanTitle,
            Overview = response.Overview,
            Monitored = response.Monitored,
            Year = response.Year,
            Genres = response.Genres,
            Added = response.Added
        };
    }
    public static Movie ToMovie(this CreateMovieCommand command)
    {
        return new Movie
        {
            ImdbId = command.ImdbId,
            Title = command.Title,
            CleanTitle = command.Title,
            Overview = command.Overview,
            Monitored = command.Monitored,
            Year = command.Year,
            Genres = command.Genres,
            Added = DateTime.Now
        };
    }
}
