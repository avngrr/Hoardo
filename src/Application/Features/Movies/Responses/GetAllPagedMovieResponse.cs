using Shared.Wrappers;

namespace Application.Features.Movies.Responses;
public class GetAllPagedMovieResponse
{
    public PagedList<MovieResponse>? MovieList { get; set; }
}
