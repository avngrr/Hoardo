using IMDbApiLib.Models;

namespace Application.Common.Interfaces.Searchers;
public interface ISearchEngine
{
    public Task<SearchData> Search(string expression);
    public Task<TitleData> GetMovieData(string imdbId);
}
