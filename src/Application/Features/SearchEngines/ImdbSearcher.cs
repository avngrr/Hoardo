using Application.Common.Interfaces.Searchers;
using IMDbApiLib;
using IMDbApiLib.Models;

namespace Application.Features.SearchEngines;
public class ImdbSearcher : ISearchEngine
{
    private readonly ApiLib _api;
    public ImdbSearcher(ApiLib api)
    {
        _api = api;
    }

    public async Task<TitleData> GetMovieData(string imdbId)
    {
        return await _api.TitleAsync(imdbId);
    }

    public async Task<SearchData> Search(string expression)
    {
        return await _api.SearchAsync(expression);
    }
}
