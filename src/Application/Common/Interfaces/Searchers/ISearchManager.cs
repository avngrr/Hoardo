using Application.Features.Movies.Responses;

namespace Application.Common.Interfaces.Searchers;
public interface ISearchManager
{
    Task<GetMovieSearchResults> GetSearchResults(string expression);
}
