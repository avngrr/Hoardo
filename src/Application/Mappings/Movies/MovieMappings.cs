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
}
